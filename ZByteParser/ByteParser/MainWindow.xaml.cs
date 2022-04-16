using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 256; i++)
            {
                cmbo_Number_RawBit.Items.Add(i);
                cmbo_Number_InsertNumberIntoByte.Items.Add(i);
                cmbo_Number_InsertbitIntoByte.Items.Add(i);
                cmbo_Value_InsertNumberIntoByte.Items.Add(i);
                cmbo_Number_GetBit.Items.Add(i);
                cmbo_Number_GetBits.Items.Add(i);
                cmbo_Number_GetbitsMSB.Items.Add(i);


            }
            cmbo_Value_InsertbitIntoByte.Items.Add(0);
            cmbo_Value_InsertbitIntoByte.Items.Add(1);
            for (int i = 0; i < 8; i++)
            {
                cmbo_index_InsertNumberIntoByte.Items.Add(i);
                cmbo_index_InsertbitIntoByte.Items.Add(i);
                cmbo_Index_GetBit.Items.Add(i);
                cmbo_Startindex_GetBits.Items.Add(i);
                cmbo_Endindex_GetBits.Items.Add(i);
                cmbo_Startindex_GetbitsMSB.Items.Add(i);
                cmbo_EndIndex_GetbitsMSB.Items.Add(i);
            }
        }
        private void cmbo_Number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_Base2_RawBit.Content = ZByteParser.GetRawBits(Convert.ToByte(cmbo_Number_RawBit.SelectedValue));
        }
        private void btn_calculate_InsertbitIntoByte_Click(object sender, RoutedEventArgs e)
        {
            byte temp = ZByteParser.InsertBitIntoByte(Convert.ToByte(cmbo_Number_InsertbitIntoByte.SelectedValue), Convert.ToByte(cmbo_index_InsertbitIntoByte.SelectedValue), Convert.ToBoolean(cmbo_Value_InsertbitIntoByte.SelectedValue));

            lbl_Decimal_InsertbitIntoByte.Content = temp.ToString();
            lbl_Base2_InsertbitIntoByte.Content = ZByteParser.GetRawBits(temp);

        }
        private void btn_Calculate_InsertNumberIntoByte_Click(object sender, RoutedEventArgs e)
        {
            byte temp = ZByteParser.InsertNumberIntoByte(Convert.ToByte(cmbo_Number_InsertNumberIntoByte.SelectedValue),Convert.ToInt32(cmbo_index_InsertNumberIntoByte.SelectedValue), Convert.ToInt32(cmbo_Value_InsertNumberIntoByte.SelectedValue));
            lbl_Decimal_InsertNumberIntoByte.Content = temp;
            lbl_Base2_InsertNumberIntoByte.Content = ZByteParser.GetRawBits(temp);
        }
        private void btn_GetBit_Click(object sender, RoutedEventArgs e)
        {
            bool value = ZByteParser.Getbit(Convert.ToByte(cmbo_Number_GetBit.SelectedValue), Convert.ToInt32(cmbo_Index_GetBit.SelectedValue));
            lbl_Value_GetBit.Content = "Bool: " + value + "\n"   +"Int:  " +Convert.ToInt32(value) ;
        }
        #region GetbitsMSB
        private void btn_Calculate_GetbitsMSB_Click(object sender, RoutedEventArgs e)
        {
            byte value = ZByteParser.GetbitsMSB(Convert.ToByte(cmbo_Number_GetbitsMSB.SelectedValue), Convert.ToInt32(cmbo_Startindex_GetbitsMSB.SelectedValue),Convert.ToInt32(cmbo_EndIndex_GetbitsMSB.SelectedValue));
            lbl_Decimal_GetbitsMSB.Content = value;
            lbl_Base2_GetbitsMSB.Content = ZByteParser.GetRawBits(value);
        }
        private void cmbo_Number_GetbitsMSB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl_Number_GetbitsMSB.Content = ZByteParser.GetRawBits(Convert.ToByte(cmbo_Number_GetbitsMSB.SelectedValue));
        }
        #endregion
    }
}
