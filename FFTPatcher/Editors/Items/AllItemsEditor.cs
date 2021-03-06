/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Windows.Forms;
using FFTPatcher.Datatypes;

namespace FFTPatcher.Editors
{
    public partial class AllItemsEditor : UserControl
    {
		#region Constructors (1) 

        public AllItemsEditor()
        {
            InitializeComponent();
            itemEditor.InflictStatusClicked += itemEditor_InflictStatusClicked;
            itemEditor.ItemAttributesClicked += itemEditor_ItemAttributesClicked;
            itemEditor.SecondTableLinkClicked += itemEditor_SecondTableLinkClicked;
            itemEditor.DataChanged += new EventHandler( itemEditor_DataChanged );
        }

		#endregion Constructors 

		#region Public Methods (1) 

        public void UpdateView( AllItems items )
        {
            itemListBox.SelectedIndexChanged -= itemListBox_SelectedIndexChanged;
            itemListBox.DataSource = items.Items;
            itemListBox.SelectedIndexChanged += itemListBox_SelectedIndexChanged;
            itemListBox.SelectedIndex = 0;
            itemEditor.Item = itemListBox.SelectedItem as Item;
        }

		#endregion Public Methods 

		#region Private Methods (5) 

        private void itemEditor_DataChanged( object sender, EventArgs e )
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[itemListBox.DataSource];
            cm.Refresh();
        }

        private void itemEditor_InflictStatusClicked( object sender, LabelClickedEventArgs e )
        {
            if( InflictStatusClicked != null )
            {
                InflictStatusClicked( this, e );
            }
        }

        private void itemEditor_ItemAttributesClicked( object sender, LabelClickedEventArgs e )
        {
            if( ItemAttributesClicked != null )
            {
                ItemAttributesClicked( this, e );
            }
        }

        private void itemEditor_SecondTableLinkClicked( object sender, LabelClickedEventArgs e )
        {
            int navigate = -1;
            switch( e.SecondTable )
            {
                case LabelClickedEventArgs.SecondTableType.Weapon:
                    if( e.Value <= 0x7F )
                        navigate = e.Value;
                    break;
                case LabelClickedEventArgs.SecondTableType.Shield:
                    if( e.Value <= 0x0F )
                        navigate = e.Value + 0x80;
                    break;
                case LabelClickedEventArgs.SecondTableType.HeadBody:
                    if( e.Value <= 0x3F )
                        navigate = e.Value + 0x90;
                    break;
                case LabelClickedEventArgs.SecondTableType.Accessory:
                    if( e.Value <= 0x1F )
                        navigate = e.Value + 0xD0;
                    break;
                case LabelClickedEventArgs.SecondTableType.ChemistItem:
                    if( e.Value <= 0x0D )
                    {
                        if( e.Value <= 0x04 )
                            navigate = e.Value + 0xF0;
                        else if( e.Value == 0x0D )
                            navigate = 0xF5;
                        else if( e.Value <= 0x0C )
                            navigate = e.Value - 0x05 + 0xF6;
                    }
                    break;

            }
            if( navigate != -1 )
            {
                itemListBox.SelectedIndex = navigate;
            }
        }

        private void itemListBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            itemEditor.Item = itemListBox.SelectedItem as Item;
        }

		#endregion Private Methods 

        public event EventHandler<LabelClickedEventArgs> InflictStatusClicked;
        public event EventHandler<LabelClickedEventArgs> ItemAttributesClicked;
    }
}
