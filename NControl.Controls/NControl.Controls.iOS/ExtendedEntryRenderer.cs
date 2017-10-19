﻿using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using NControl.Controls;
using NControl.Controls.iOS;

[assembly: ExportRenderer (typeof (ExtendedEntry), typeof (ExtendedEntryRenderer))]
namespace NControl.Controls.iOS
{
	public class ExtendedEntryRenderer: EntryRenderer
	{
        private new ExtendedEntry Element => (ExtendedEntry)base.Element;
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged (e);

            if (Control != null && e.NewElement != null) 
			{
				var textfield = Control as UITextField;
				textfield.BorderStyle = UITextBorderStyle.None;
                UpdateFont(e.NewElement as ExtendedEntry);
                if (Element.Keyboard.Equals(Keyboard.Plain))
                {
                    Control.SpellCheckingType = UITextSpellCheckingType.No;
                    Control.AutocorrectionType = UITextAutocorrectionType.No;
                    Control.AutocapitalizationType = UITextAutocapitalizationType.None;
                }
			}

			if (e.NewElement != null)
				UpdateTextAlignment ();
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
				UpdateTextAlignment ();		
			else if (e.PropertyName == Entry.FontFamilyProperty.PropertyName)
                UpdateFont (Element as ExtendedEntry);            
		}

		/// <summary>
		/// Updates the font.
		/// </summary>
        private void UpdateFont (ExtendedEntry element)
		{
            if (string.IsNullOrEmpty(element.FontFamily))
                return;
            
			(Control as UITextField).Font = UIFont.FromName (element.FontFamily, 
				(Control as UITextField).Font.PointSize);
		}

		/// <summary>
		/// Updates the text alignment.
		/// </summary>
		private void UpdateTextAlignment()
		{
			if (Control == null)
				return;

            if ((Element as ExtendedEntry).HorizontalTextAlignment == TextAlignment.Start)
                (Control as UITextField).TextAlignment = UITextAlignment.Left;
            else if ((Element as ExtendedEntry).HorizontalTextAlignment == TextAlignment.Center)
                (Control as UITextField).TextAlignment = UITextAlignment.Center;
            else if ((Element as ExtendedEntry).HorizontalTextAlignment == TextAlignment.End)
                (Control as UITextField).TextAlignment = UITextAlignment.Right;
        }
	}
}

