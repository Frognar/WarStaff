using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Frognar {
  //Original by DYLAN ENGELMAN http://jupiterlighthousestudio.com/custom-inspectors-unity/
  //Altered by Brecht Lecluyse http://www.brechtos.com
  [CustomPropertyDrawer(typeof(TagSelectorAttribute))]
  public class TagSelectorPropertyDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      if (property.propertyType == SerializedPropertyType.String) {
        _ = EditorGUI.BeginProperty(position, label, property);
        TagSelectorAttribute attrib = attribute as TagSelectorAttribute;

        if (attrib.UseDefaultTagFieldDrawer) {
          property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
        else {
          string[] tags = GenerateTagList();
          int selectedTag = GetIndexOfSelectedTag(tags, property.stringValue);
          selectedTag = EditorGUI.Popup(position, label.text, selectedTag, tags);
          SetPropertyBasedOn(selectedTag, property, tags);
        }

        EditorGUI.EndProperty();
      }
      else {
        _ = EditorGUI.PropertyField(position, property, label);
      }
    }

    string[] GenerateTagList() {
      List<string> tagList = new List<string> { "<NoTag>" };
      tagList.AddRange(UnityEditorInternal.InternalEditorUtility.tags);
      return tagList.ToArray();
    }

    int GetIndexOfSelectedTag(string[] tags, string propertyString) {
      if (string.IsNullOrEmpty(propertyString)) {
        return 0;
      }
      for (int i = 1; i < tags.Length; i++) {
        if (tags[i] == propertyString) {
          return i;
        }
      }
      return -1;
    }

    void SetPropertyBasedOn(int index, SerializedProperty property, string[] tagList) {
      const int NO_TAG = 0;
      if (index == NO_TAG) {
        property.stringValue = string.Empty;
      }
      else if (index >= 1) {
        property.stringValue = tagList[index];
      }
      else {
        property.stringValue = string.Empty;
      }
    }
  }
}