using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent;
using System.Collections.Generic;
using Terraria.Localization;

namespace TerraFlipper.Common.Player
{
	// This custom UI will show whenever the player is holding the ExampleCustomResourceWeapon item and will display the player's custom resource amounts that are tracked in ExampleResourcePlayer
	internal class EnergyBar1 : UIState
	{
		// For this bar we'll be using a frame texture and then a gradient inside bar, as it's one of the more simpler approaches while still looking decent.
		// Once this is all set up make sure to go and do the required stuff for most UI's in the ModSystem class.
		private UIText text;
		private UIElement area;
		private UIImage barFrame;
		private Color gradientA;
		private Color gradientB;

		public override void OnInitialize()
		{
			// Create a UIElement for all the elements to sit on top of, this simplifies the numbers as nested elements can be positioned relative to the top left corner of this element. 
			// UIElement is invisible and has no padding.
			area = new UIElement();
			area.Left.Set(-area.Width.Pixels - 400, 1f); // Place the resource bar to the left of the hearts.
			area.Top.Set(70, 0f); // Placing it just a bit below the top of the screen.
			area.Width.Set(90, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
			area.Height.Set(40, 0f);

			barFrame = new UIImage(ModContent.Request<Texture2D>("TerraFlipper/Common/Player/FeverBar")); // Frame of our resource bar
			barFrame.Left.Set(11, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(71, 0f);
			barFrame.Height.Set(19, 0f);

			text = new UIText("0/0", 0.8f); // text to show stat
			text.Width.Set(79, 0f);
			text.Height.Set(19, 0f);
			text.Top.Set(40, 0f);
			text.Left.Set(20, 0f);

			gradientA = new Color(255, 255, 0);
			gradientB = new Color(255, 250, 205);

			area.Append(text);
			area.Append(barFrame);
			Append(area);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		// Here we draw our UI
		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			// Calculate quotient
			float quotient = (float)Main.LocalPlayer.GetModPlayer<Energy1>().CurrentEnergy / Main.LocalPlayer.GetModPlayer<Energy1>().DefaultEnergyMax; // Creating a quotient that represents the difference of your currentResource vs your maximumResource, resulting in a float of 0-1f.
			quotient = Utils.Clamp(quotient, 0f, 1f); // Clamping it to 0-1f so it doesn't go over that.

			// Here we get the screen dimensions of the barFrame element, then tweak the resulting rectangle to arrive at a rectangle within the barFrame texture that we will draw the gradient. These values were measured in a drawing program.
			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 5;
			hitbox.Width -= 10;
			hitbox.Y += 3;
			hitbox.Height -= 6;

			// Now, using this hitbox, we draw a gradient by drawing vertical lines while slowly interpolating between the 2 colors.
			int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * quotient);
			for (int i = 0; i < steps; i += 1)
			{
				// float percent = (float)i / steps; // Alternate Gradient Approach
				float percent = (float)i / (right - left);
				spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
			}
		}

		public override void Update(GameTime gameTime)
		{
			var modPlayer = Main.LocalPlayer.GetModPlayer<Energy1>();
			// Setting the text per tick to update and show our resource values.
			text.SetText(Energy1UISystem.Energy1Text.Format(modPlayer.CurrentEnergy, modPlayer.DefaultEnergyMax));
			base.Update(gameTime);
		}
	}

	// This class will only be autoloaded/registered if we're not loading on a server
	[Autoload(Side = ModSide.Client)]
	internal class Energy1UISystem : ModSystem
	{
		private UserInterface Energy1BarUserInterface;

		internal EnergyBar1 Energy1Bar;

		public static LocalizedText Energy1Text { get; private set; }

		public override void Load()
		{
			Energy1Bar = new();
			Energy1BarUserInterface = new();
			Energy1BarUserInterface.SetState(Energy1Bar);

			string category = "UI";
			Energy1Text ??= Language.GetOrRegister(Mod.GetLocalizationKey($"{category}.Energy1"));
		}

		public override void UpdateUI(GameTime gameTime)
		{
			Energy1BarUserInterface?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"Energy Bar 1",
					delegate {
						Energy1BarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}