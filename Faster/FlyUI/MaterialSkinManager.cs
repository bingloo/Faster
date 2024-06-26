﻿using FlyUI.MaterialControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlyUI.Library.MaterialLibs
{
    public class MaterialSkinManager
    {
        //Singleton instance
        private static MaterialSkinManager instance;

        //Theme
        private Themes theme;
        public Themes Theme
        {
            get { return theme; }
            set
            {
                theme = value;
            }
        }

        private ColorScheme colorScheme;
        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
            set
            {
                colorScheme = value;
            }
        }

        public enum Themes : byte
        {
            LIGHT,
            DARK
        }

        //Constant color values
        private static readonly Color PRIMARY_TEXT_BLACK = Color.FromArgb(222, 0, 0, 0);
        private static readonly Brush PRIMARY_TEXT_BLACK_BRUSH = new SolidBrush(PRIMARY_TEXT_BLACK);
        public static Color SECONDARY_TEXT_BLACK = Color.FromArgb(138, 0, 0, 0);
        public static Brush SECONDARY_TEXT_BLACK_BRUSH = new SolidBrush(SECONDARY_TEXT_BLACK);
        private static readonly Color DISABLED_OR_HINT_TEXT_BLACK = Color.FromArgb(66, 0, 0, 0);
        private static readonly Brush DISABLED_OR_HINT_TEXT_BLACK_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_BLACK);
        private static readonly Color DIVIDERS_BLACK = Color.FromArgb(31, 0, 0, 0);
        private static readonly Brush DIVIDERS_BLACK_BRUSH = new SolidBrush(DIVIDERS_BLACK);

        private static readonly Color PRIMARY_TEXT_WHITE = Color.FromArgb(255, 255, 255, 255);
        private static readonly Brush PRIMARY_TEXT_WHITE_BRUSH = new SolidBrush(PRIMARY_TEXT_WHITE);
        public static Color SECONDARY_TEXT_WHITE = Color.FromArgb(179, 255, 255, 255);
        public static Brush SECONDARY_TEXT_WHITE_BRUSH = new SolidBrush(SECONDARY_TEXT_WHITE);
        private static readonly Color DISABLED_OR_HINT_TEXT_WHITE = Color.FromArgb(77, 255, 255, 255);
        private static readonly Brush DISABLED_OR_HINT_TEXT_WHITE_BRUSH = new SolidBrush(DISABLED_OR_HINT_TEXT_WHITE);
        private static readonly Color DIVIDERS_WHITE = Color.FromArgb(31, 255, 255, 255);
        private static readonly Brush DIVIDERS_WHITE_BRUSH = new SolidBrush(DIVIDERS_WHITE);

        // Checkbox colors
        private static readonly Color CHECKBOX_OFF_LIGHT = Color.FromArgb(138, 0, 0, 0);
        private static readonly Brush CHECKBOX_OFF_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_LIGHT);
        private static readonly Color CHECKBOX_OFF_DISABLED_LIGHT = Color.FromArgb(66, 0, 0, 0);
        private static readonly Brush CHECKBOX_OFF_DISABLED_LIGHT_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_LIGHT);

        private static readonly Color CHECKBOX_OFF_DARK = Color.FromArgb(179, 255, 255, 255);
        private static readonly Brush CHECKBOX_OFF_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DARK);
        private static readonly Color CHECKBOX_OFF_DISABLED_DARK = Color.FromArgb(77, 255, 255, 255);
        private static readonly Brush CHECKBOX_OFF_DISABLED_DARK_BRUSH = new SolidBrush(CHECKBOX_OFF_DISABLED_DARK);

        //Raised button
        private static readonly Color RAISED_BUTTON_BACKGROUND = Color.FromArgb(255, 255, 255, 255);
        private static readonly Brush RAISED_BUTTON_BACKGROUND_BRUSH = new SolidBrush(RAISED_BUTTON_BACKGROUND);
        private static readonly Color RAISED_BUTTON_TEXT_LIGHT = PRIMARY_TEXT_WHITE;
        private static readonly Brush RAISED_BUTTON_TEXT_LIGHT_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_LIGHT);
        private static readonly Color RAISED_BUTTON_TEXT_DARK = PRIMARY_TEXT_BLACK;
        private static readonly Brush RAISED_BUTTON_TEXT_DARK_BRUSH = new SolidBrush(RAISED_BUTTON_TEXT_DARK);

        //Flat button
        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_LIGHT = Color.FromArgb(20.PercentageToColorComponent(), 0x999999.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_LIGHT);
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT = Color.FromArgb(40.PercentageToColorComponent(), 0x999999.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT);
        private static readonly Color FLAT_BUTTON_DISABLEDTEXT_LIGHT = Color.FromArgb(26.PercentageToColorComponent(), 0x000000.ToColor());
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH = new SolidBrush(FLAT_BUTTON_DISABLEDTEXT_LIGHT);

        private static readonly Color FLAT_BUTTON_BACKGROUND_HOVER_DARK = Color.FromArgb(15.PercentageToColorComponent(), 0xCCCCCC.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_HOVER_DARK);
        private static readonly Color FLAT_BUTTON_BACKGROUND_PRESSED_DARK = Color.FromArgb(25.PercentageToColorComponent(), 0xCCCCCC.ToColor());
        private static readonly Brush FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_BACKGROUND_PRESSED_DARK);
        private static readonly Color FLAT_BUTTON_DISABLEDTEXT_DARK = Color.FromArgb(30.PercentageToColorComponent(), 0xFFFFFF.ToColor());
        private static readonly Brush FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH = new SolidBrush(FLAT_BUTTON_DISABLEDTEXT_DARK);

        //ContextMenuStrip
        private static readonly Color CMS_BACKGROUND_LIGHT_HOVER = Color.FromArgb(255, 238, 238, 238);

        //private static readonly Color CMS_BACKGROUND_LIGHT_HOVER = Color.DodgerBlue;
        private static readonly Brush CMS_BACKGROUND_HOVER_LIGHT_BRUSH = new SolidBrush(CMS_BACKGROUND_LIGHT_HOVER);

        private static readonly Color CMS_BACKGROUND_DARK_HOVER = Color.FromArgb(38, 204, 204, 204);
        private static readonly Brush CMS_BACKGROUND_HOVER_DARK_BRUSH = new SolidBrush(CMS_BACKGROUND_DARK_HOVER);

        //Application background
        private static readonly Color BACKGROUND_LIGHT = Color.FromArgb(255, 255, 255, 255);
        private static Brush BACKGROUND_LIGHT_BRUSH = new SolidBrush(BACKGROUND_LIGHT);

        private static readonly Color BACKGROUND_DARK = Color.FromArgb(255, 51, 51, 51);
        private static Brush BACKGROUND_DARK_BRUSH = new SolidBrush(BACKGROUND_DARK);

        //Application action bar
        public readonly Color ACTION_BAR_TEXT = Color.FromArgb(255, 255, 255, 255);
        public readonly Brush ACTION_BAR_TEXT_BRUSH = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
        public readonly Color ACTION_BAR_TEXT_SECONDARY = Color.FromArgb(153, 255, 255, 255);
        public readonly Brush ACTION_BAR_TEXT_SECONDARY_BRUSH = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

        public Color GetPrimaryTextColor()
        {
            return (Theme == Themes.LIGHT ? PRIMARY_TEXT_BLACK : PRIMARY_TEXT_WHITE);
        }

        public Brush GetPrimaryTextBrush()
        {
            return (Theme == Themes.LIGHT ? PRIMARY_TEXT_BLACK_BRUSH : PRIMARY_TEXT_WHITE_BRUSH);
        }

        public Color GetSecondaryTextColor()
        {
            return (Theme == Themes.LIGHT ? SECONDARY_TEXT_BLACK : SECONDARY_TEXT_WHITE);
        }

        public Brush GetSecondaryTextBrush()
        {
            return (Theme == Themes.LIGHT ? SECONDARY_TEXT_BLACK_BRUSH : SECONDARY_TEXT_WHITE_BRUSH);
        }

        public Color GetDisabledOrHintColor()
        {
            return (Theme == Themes.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK : DISABLED_OR_HINT_TEXT_WHITE);
        }

        public Brush GetDisabledOrHintBrush()
        {
            return (Theme == Themes.LIGHT ? DISABLED_OR_HINT_TEXT_BLACK_BRUSH : DISABLED_OR_HINT_TEXT_WHITE_BRUSH);
        }

        public Color GetDividersColor()
        {
            return (Theme == Themes.LIGHT ? DIVIDERS_BLACK : DIVIDERS_WHITE);
        }

        public Brush GetDividersBrush()
        {
            return (Theme == Themes.LIGHT ? DIVIDERS_BLACK_BRUSH : DIVIDERS_WHITE_BRUSH);
        }

        public Color GetCheckboxOffColor()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_LIGHT : CHECKBOX_OFF_DARK);
        }

        public Brush GetCheckboxOffBrush()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_LIGHT_BRUSH : CHECKBOX_OFF_DARK_BRUSH);
        }

        public Color GetCheckBoxOffDisabledColor()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT : CHECKBOX_OFF_DISABLED_DARK);
        }

        public Brush GetCheckBoxOffDisabledBrush()
        {
            return (Theme == Themes.LIGHT ? CHECKBOX_OFF_DISABLED_LIGHT_BRUSH : CHECKBOX_OFF_DISABLED_DARK_BRUSH);
        }

        public Brush GetRaisedButtonBackgroundBrush()
        {
            return RAISED_BUTTON_BACKGROUND_BRUSH;
        }

        public Brush GetRaisedButtonTextBrush(bool primary)
        {
            return (primary ? RAISED_BUTTON_TEXT_LIGHT_BRUSH : RAISED_BUTTON_TEXT_DARK_BRUSH);
        }

        public Color GetFlatButtonHoverBackgroundColor()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT : FLAT_BUTTON_BACKGROUND_HOVER_DARK);
        }

        public Brush GetFlatButtonHoverBackgroundBrush()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_HOVER_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_HOVER_DARK_BRUSH);
        }

        public Color GetFlatButtonPressedBackgroundColor()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT : FLAT_BUTTON_BACKGROUND_PRESSED_DARK);
        }

        public Brush GetFlatButtonPressedBackgroundBrush()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_BACKGROUND_PRESSED_LIGHT_BRUSH : FLAT_BUTTON_BACKGROUND_PRESSED_DARK_BRUSH);
        }

        public Brush GetFlatButtonDisabledTextBrush()
        {
            return (Theme == Themes.LIGHT ? FLAT_BUTTON_DISABLEDTEXT_LIGHT_BRUSH : FLAT_BUTTON_DISABLEDTEXT_DARK_BRUSH);
        }

        public Brush GetCmsSelectedItemBrush()
        {
            return (Theme == Themes.LIGHT ? CMS_BACKGROUND_HOVER_LIGHT_BRUSH : CMS_BACKGROUND_HOVER_DARK_BRUSH);
        }

        public Color GetApplicationBackgroundColor()
        {
            return (Theme == Themes.LIGHT ? BACKGROUND_LIGHT : BACKGROUND_DARK);
        }

        //Roboto font
        public Font ROBOTO_MEDIUM_12;
        public Font ROBOTO_REGULAR_11;
        public Font ROBOTO_MEDIUM_11;
        public Font ROBOTO_MEDIUM_10;

        //Other constants
        public int FORM_PADDING = 14;

        private MaterialSkinManager()
        {

            //ROBOTO_MEDIUM_12 = new Font(LoadFont(Resources.Roboto_Medium), 12f);
            //ROBOTO_MEDIUM_10 = new Font(LoadFont(Resources.Roboto_Medium), 10f);
            //ROBOTO_REGULAR_11 = new Font(LoadFont(Resources.Roboto_Regular), 11f);
            //ROBOTO_MEDIUM_11 = new Font(LoadFont(Resources.Roboto_Medium), 11f);
            //ROBOTO_MEDIUM_12 = new Font("Microsoft YaHei UI", 12f);
            //ROBOTO_MEDIUM_10 = new Font("Microsoft YaHei UI", 10f);
            //ROBOTO_REGULAR_11 = new Font("Microsoft YaHei UI", 11f);
            //ROBOTO_MEDIUM_11 = new Font("Microsoft YaHei UI", 11f);
            ROBOTO_MEDIUM_12 = new Font("Microsoft YaHei UI", 9f);
            ROBOTO_MEDIUM_10 = new Font("Microsoft YaHei UI", 9f);
            ROBOTO_REGULAR_11 = new Font("Microsoft YaHei UI", 9f);
            ROBOTO_MEDIUM_11 = new Font("Microsoft YaHei UI", 9f);
            Theme = Themes.LIGHT;
            ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public static MaterialSkinManager Instance
        {
            get { return instance ?? (instance = new MaterialSkinManager()); }
        }

        private void UpdateControl(Control controlToUpdate, Color newBackColor)
        {
            if (controlToUpdate == null) return;

            //if (controlToUpdate is Material_ListView)
            //{
            //    controlToUpdate.BackColor = newBackColor;

            //}

            //recursive call
            foreach (Control control in controlToUpdate.Controls)
            {
                UpdateControl(control, newBackColor);
            }

            controlToUpdate.Invalidate();
        }
    }
}
