using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(IntReference))]
public class IntReferenceDrawer : PropertyDrawer
{
    private readonly string[] popupOptions = { "Use Simple", "Use Variable" };

    /// <summary> Cached style to use to draw the popup button. </summary>
    private GUIStyle popupStyle;

    SerializedProperty useSimpleProperty;
    SerializedProperty variableProperty;
    SerializedProperty simpleValueProperty;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI( position, property, label );
        label = EditorGUI.BeginProperty( position, label, property );

        position = EditorGUI.PrefixLabel( position, label );

        // Get Properties
        GetProperties( property );

        // Draw button
        // Create Style
        popupStyle ??= new GUIStyle( GUI.skin.GetStyle( "PaneOptions" ) )
        {
            imagePosition = ImagePosition.ImageOnly
        };

        // Calculate Button rect
        var buttonRect = new Rect( position );
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;

        position.xMin = buttonRect.xMax;

        var selectedIndex = useSimpleProperty.boolValue ? 0 : 1;
        var result = EditorGUI.Popup( buttonRect, selectedIndex, popupOptions, popupStyle );
        useSimpleProperty.boolValue = result == 0;

        var propertyToDraw = useSimpleProperty.boolValue ? simpleValueProperty : variableProperty;
        EditorGUI.PropertyField( position, propertyToDraw, GUIContent.none );

        EditorGUI.EndProperty();
    }

    private void GetProperties(SerializedProperty property)
    {
        useSimpleProperty = property.FindPropertyRelative( IntReference.UseSimpleValueName );
        variableProperty = property.FindPropertyRelative( IntReference.VariableName );
        simpleValueProperty = property.FindPropertyRelative( IntReference.SimpleValueName );
    }

    private static Rect DrawPropertyName(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty( position, label, property );
        position = EditorGUI.PrefixLabel( position, label );
        return position;
    }

    private bool ShowPopup(SerializedProperty useConstant, Rect buttonRect)
    {
        var result = EditorGUI.Popup( buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle );
        return result == 0;
    }
}
