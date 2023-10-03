using Terraria.ModLoader;

namespace TerraFlipper.Common.Key
{
	// Acts as a container for keybinds registered by this mod.
	// See Common/Players/ExampleKeybindPlayer for usage.
	public class Key1 : ModSystem
	{
		public static ModKeybind JiNeng1 { get; private set; }
		
		public override void Load()
		{
			// Registers a new keybind
			// We localize keybinds by adding a Mods.{ModName}.Keybind.{KeybindName} entry to our localization files. The actual text displayed to english users is in en-US.hjson
			JiNeng1 = KeybindLoader.RegisterKeybind(Mod, "Key1", ",");
		}

		// Please see ExampleMod.cs' Unload() method for a detailed explanation of the unloading process.
		public override void Unload()
		{
			// Not required if your AssemblyLoadContext is unloading properly, but nulling out static fields can help you figure out what's keeping it loaded.
			JiNeng1 = null;
		}
	}
}