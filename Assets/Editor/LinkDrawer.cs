using System.Collections.Generic;
using Modular;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    [CustomPropertyDrawer(typeof(LinkBase), true)]
    public class LinkDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            EditorGUI.BeginProperty(position, label, property);
            var linked = !property.FindPropertyRelative("useHardValue").boolValue;
            Rect rect;
            var yPos = position.min.y;
            
            if (!linked)
            {
                rect = new Rect(position.min.x, yPos, position.size.x * 0.8f, EditorGUIUtility.singleLineHeight);
                EditorGUI.PropertyField(rect, property.FindPropertyRelative("constantValue"), label);
                rect = new Rect(position.min.x + position.size.x * 0.82f, yPos, position.size.x * 0.18f,
                    EditorGUIUtility.singleLineHeight);
                property.FindPropertyRelative("useHardValue").boolValue = !EditorGUI.LinkButton(rect, "Link");
            }
            else
            {
                rect = new Rect(position.min.x, yPos, position.size.x * 0.8f,
                    EditorGUIUtility.singleLineHeight);
                property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, label);
                rect = new Rect(position.min.x + position.size.x * 0.82f, yPos, position.size.x * 0.18f,
                    EditorGUIUtility.singleLineHeight);
                property.FindPropertyRelative("useHardValue").boolValue = EditorGUI.LinkButton(rect, "Unlink");
                yPos += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                if (property.isExpanded)
                {
                    rect = new Rect(position.min.x, yPos, position.size.x, EditorGUIUtility.singleLineHeight);
                    EditorGUI.PropertyField(rect, property.FindPropertyRelative("linkedObject"));
                    yPos += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    rect = new Rect(position.min.x, yPos, position.size.x, EditorGUIUtility.singleLineHeight);

                    if (HasAttachments(property.FindPropertyRelative("linkedObject").objectReferenceValue))
                    {
                        int selected;
                        var list = AttachmentList(property.FindPropertyRelative("linkedObject").objectReferenceValue,
                            property.FindPropertyRelative("attachmentName").stringValue, out selected);
                        selected = EditorGUI.Popup(rect, "Attachment", selected, list);
                        property.FindPropertyRelative("attachmentName").stringValue = selected >= 0 ? list[selected] : "";

                        yPos += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                        rect = new Rect(position.min.x, yPos, position.size.x, EditorGUIUtility.singleLineHeight);

                        var attachment = LoadAttachment(property.FindPropertyRelative("linkedObject").objectReferenceValue,
                            property.FindPropertyRelative("attachmentName").stringValue);
                        if (attachment)
                        {
                            string[] exportList = null;
                            if (property.type.Equals("BoolLink"))
                                exportList = attachment.LinkedBoolNames;
                            else if (property.type.Equals("IntLink"))
                                exportList = attachment.LinkedIntNames;
                            else if (property.type.Equals("FloatLink"))
                                exportList = attachment.LinkedFloatNames;
                            else if (property.type.Equals("Vector2Link"))
                                exportList = attachment.LinkedVector2Names;
                            else if (property.type.Equals("Vector3Link"))
                                exportList = attachment.LinkedVector3Names;
                            else
                                EditorGUI.LabelField(rect, "Invalid: Type not known");

                            if (exportList != null && exportList.Length == 0)
                            {
                                EditorGUI.LabelField(rect, "No exported fields of this type");
                            }
                            else
                            {
                                var sel = FindSelected(exportList, property.FindPropertyRelative("valueName").stringValue);
                                sel = EditorGUI.Popup(rect, "Linked Field", sel, exportList);
                                property.FindPropertyRelative("valueName").stringValue = sel >= 0 ? exportList[sel] : "";
                            }
                        }
                        else
                        {
                            EditorGUI.LabelField(rect, "Select a valid attachment");
                        }
                    }
                    else
                        EditorGUI.LabelField(rect, "Select an Object with Attachments");
                }
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var totalLines = 0;
            if (property.FindPropertyRelative("useHardValue").boolValue) totalLines = 1;
            else if (property.isExpanded) totalLines = 4;
            else totalLines = 1;
            return EditorGUIUtility.singleLineHeight * totalLines + EditorGUIUtility.standardVerticalSpacing * (totalLines - 1);
        }

        private bool HasAttachments(Object mainObject)
        {
            return mainObject && ((GameObject)mainObject).GetComponents<Attachment>().Length != 0;
        }

        private string[] AttachmentList(Object mainObject, string current, out int selected)
        {
            var list = ((GameObject)mainObject).GetComponents<Attachment>();
            var ret = new List<string>();
            selected = -1;

            for (int counter = 0; counter < list.Length; counter++)
            {
                if (current.Equals(list[counter].AttachmentName))
                    selected = counter;
                ret.Add(list[counter].AttachmentName);
            }

            return ret.ToArray();
        }

        private Attachment LoadAttachment(Object mainObject, string attachmentName)
        {
            var list = ((GameObject)mainObject).GetComponents<Attachment>();
            foreach (var item in list)
            {
                if (item.AttachmentName.Equals(attachmentName))
                    return item;
            }

            return null;
        }

        private int FindSelected(string[] list, string value)
        {
            for(int counter=0; counter < list.Length; counter++)
                if (list[counter].Equals(value))
                    return counter;
            return -1;
        }
    }
}
