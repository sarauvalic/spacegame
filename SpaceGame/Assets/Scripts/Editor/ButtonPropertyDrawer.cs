using SpaceGame.Attributes;
using UnityEditor;
using UnityEngine;

namespace SpaceGame.EditorExstensions
{
	[CustomPropertyDrawer(typeof(ButtonAttribute))]
	public class ButtonPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			string methodName = (attribute as ButtonAttribute).name;
			Object target = property.serializedObject.targetObject;
			System.Type type = target.GetType();
			System.Reflection.MethodInfo method = type.GetMethod(methodName);
			if (method == null)
			{
				GUI.Label(position, "Method could not be found. Is it public?");
				return;
			}
			if (method.GetParameters().Length > 0)
			{
				GUI.Label(position, "Method cannot have parameters.");
				return;
			}
			if (GUI.Button(position, method.Name))
			{
				method.Invoke(target, null);
			}
		}
	}
}