#if UNITY_EDITOR
//Narek Hovsepyan 2022 TMP HTMl editor
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TMPHTMLEditor : EditorWindow
{
    
    string _text = "Your Text";    
    string _resultView;
    Color _color;
    float _fontSizePoints = 30;
    float _fontSizeProcent = 120;
    string _fontName;
    string _fontMaterial;
    float _lineHeight;
    float _characterSpacing;
    float _verticalOffset;
    Vector2 scrollPosition = Vector2.zero;
    int selGridInt = 0;
    string[] selStrings = { "Font Size in points (default,static)", "Font Size in % from TMP Font Size (Dynamic)" };

    [MenuItem("Window/TextMeshPro/TMP HTML editor by Nik.H")]
    public static void ShowWindow()
    {
        GetWindow<TMPHTMLEditor>("TMP HTML Editor");
    }

    void OnGUI()
    {   

        GUILayout.Label("Text Mesh Pro HTML Editor by Narek Nik.H.", EditorStyles.boldLabel);
        GUILayout.Space(10);
        GUILayout.Label("Text to modify");
        _text = EditorGUILayout.TextArea(_text, GUILayout.Height(50));        
        GUILayout.Space(20);
        GUILayout.Label("Result - set html tag to see result");
        _resultView = EditorGUILayout.TextArea(_text, GUILayout.Height(50));

        GUILayout.Label("============================================");
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.MaxWidth(550), GUILayout.MaxHeight(850));
        
        selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 1, EditorStyles.radioButton);
        GUILayout.Space(10);
        if (selGridInt == 0)
        {
            _fontSizePoints = EditorGUILayout.FloatField("Font Size in points(Static)", _fontSizePoints);
            if (GUILayout.Button("Size tag - Size in points (default)"))
            {
                _text = EditorGUILayout.TextField("", "<size=" + _fontSizePoints + ">" + _text + "</size>");
            }
        }
        else
        {
            _fontSizeProcent = EditorGUILayout.FloatField("Font Size in % (Dynamic)", _fontSizeProcent);
            if (GUILayout.Button("Size tag - Size in % from font size"))
            {
                _text = EditorGUILayout.TextField("", "<size=" + _fontSizeProcent + "%>" + _text + "</size>");
            }
        }
        GUILayout.Space(10);
        _color = EditorGUILayout.ColorField("Set color for color tag", _color);
        if (GUILayout.Button("Color tag"))
        {
            _text = EditorGUILayout.TextField("", "<color=#" + ColorUtility.ToHtmlStringRGB(_color) + ">" + _text + "</color>");
        }
        if (GUILayout.Button("Sprite tag - Use name"))
        {
            _text = EditorGUILayout.TextField("", "<sprite name=" + '\"' + _text + '\"' + ">");
        }
        GUILayout.Label("============================================");
        _characterSpacing = EditorGUILayout.FloatField("Character Spacing in points", _characterSpacing);
        if (GUILayout.Button("Character Spacing tag"))
        {
            _text = EditorGUILayout.TextField("", "<cspace="+ _characterSpacing + ">" + _text + "</cspace>");
        }
        _verticalOffset = EditorGUILayout.FloatField("Vertical Offset in em", _verticalOffset);
        if (GUILayout.Button("Vertical Offset tag"))
        {
            _text = EditorGUILayout.TextField("", "<voffset=" + _verticalOffset + "em>" + _text + "</voffset>");
        }
        _lineHeight = EditorGUILayout.FloatField("Line Height in % (Dynamic)", _lineHeight);
        if (GUILayout.Button("Line Height tag"))
        {
            _text = EditorGUILayout.TextField("", "<line-height="+ _lineHeight + "%>" + _text);
        }
        GUILayout.Label("============================================");
        if (GUILayout.Button("Bold tag - Apply bold"))
        {
            _text = EditorGUILayout.TextField("", "<b>" + _text + "</b>");
        }
        if (GUILayout.Button("Italic  tag - Apply italic"))
        {
            _text = EditorGUILayout.TextField("", "<i>" + _text + "</i>");
        }
        if (GUILayout.Button("Strikethrough tag"))
        {
            _text = EditorGUILayout.TextField("", "<s>" + _text + "</s>");
        }
        if (GUILayout.Button("Underline tag"))
        {
            _text = EditorGUILayout.TextField("", "<u>" + _text + "</u>");
        }
        if (GUILayout.Button("Lowercase tag"))
        {
            _text = EditorGUILayout.TextField("", "<lowercase>" + _text + "</lowercase>");
        }
        if (GUILayout.Button("Uppercase tag"))
        {
            _text = EditorGUILayout.TextField("", "<uppercase>" + _text + "</uppercase>");
        }
        if (GUILayout.Button("Smallcaps tag"))
        {
            _text = EditorGUILayout.TextField("", "<smallcaps>" + _text + "</smallcaps>");
        }
        if (GUILayout.Button("Subscript tag"))
        {
            _text = EditorGUILayout.TextField("", "<sup>" + _text + "</sup>");
        }
        if (GUILayout.Button("Superscript tag"))
        {
            _text = EditorGUILayout.TextField("", "<sub>" + _text + "</sub>");
        }
        if (GUILayout.Button("Mark tag - HEX colors + alpha"))
        {
            _text = EditorGUILayout.TextField("", "<mark=#ffff00aa>" + _text + "</mark>");
        }
        GUILayout.Space(20);
        GUILayout.Label("Before using Font tag make sure your font is in");
        GUILayout.Label("TextMesh Pro>Recurses>Fonts & Materials >>folder<<");
        _fontName = EditorGUILayout.TextField("Font name", _fontName);
        _fontMaterial = EditorGUILayout.TextField("Font material name", _fontMaterial);
        if (GUILayout.Button("Font tag - Change text font"))
        {
            _text = EditorGUILayout.TextField("", "<font=" + '\"' + _fontName + '\"' + " material=" + '\"' + _fontMaterial + '\"' + ">" + _text + "</font>");
        }
        GUILayout.EndScrollView();
    }
}
#endif
