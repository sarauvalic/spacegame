using UnityEngine;

namespace SpaceGame.Attributes
{
	public class ButtonAttribute : PropertyAttribute
	{
		public readonly string name;

		public ButtonAttribute(string name)
		{
			this.name = name;
		}
	}
}