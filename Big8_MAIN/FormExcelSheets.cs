using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Big8_MAIN
{
    public partial class FormExcelSheets : Form
    {
        // lists to store all of the possible nfl and college teams
        List<string> NFLTeamList = new List<string>();
        List<string> CollegeTeamList = new List<string>();
        // lists to store the actual teams playing each week
        List<string> Week01TeamsList = new List<string>();
        List<string> Week02TeamsList = new List<string>();
        List<string> Week03TeamsList = new List<string>();
        List<string> Week04TeamsList = new List<string>();
        List<string> Week05TeamsList = new List<string>();
        List<string> Week06TeamsList = new List<string>();
        List<string> Week07TeamsList = new List<string>();
        List<string> Week08TeamsList = new List<string>();
        List<string> Week09TeamsList = new List<string>();
        List<string> Week10TeamsList = new List<string>();
        List<string> Week11TeamsList = new List<string>();
        List<string> Week12TeamsList = new List<string>();
        List<string> Week13TeamsList = new List<string>();
        List<string> Week14TeamsList = new List<string>();
        List<string> Week15TeamsList = new List<string>();
        List<string> Week16TeamsList = new List<string>();
        List<string> Week17TeamsList = new List<string>();
        // strings to store the bye week teams for each week
        string byeTeamsWeek01 = "BYE WEEK: ";
        string byeTeamsWeek02 = "BYE WEEK: ";
        string byeTeamsWeek03 = "BYE WEEK: ";
        string byeTeamsWeek04 = "BYE WEEK: ";
        string byeTeamsWeek05 = "BYE WEEK: ";
        string byeTeamsWeek06 = "BYE WEEK: ";
        string byeTeamsWeek07 = "BYE WEEK: ";
        string byeTeamsWeek08 = "BYE WEEK: ";
        string byeTeamsWeek09 = "BYE WEEK: ";
        string byeTeamsWeek10 = "BYE WEEK: ";
        string byeTeamsWeek11 = "BYE WEEK: ";
        string byeTeamsWeek12 = "BYE WEEK: ";
        string byeTeamsWeek13 = "BYE WEEK: ";
        string byeTeamsWeek14 = "BYE WEEK: ";
        string byeTeamsWeek15 = "BYE WEEK: ";
        string byeTeamsWeek16 = "BYE WEEK: ";
        string byeTeamsWeek17 = "BYE WEEK: ";

        public FormExcelSheets()
        {
            InitializeComponent();

            
        }

        private void buttonMasterSheet_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((System.Windows.Forms.Application.OpenForms["FormMasterSheet"] as FormMasterSheet) != null)
            {
                // if it is then select the right form
                foreach (Form form in System.Windows.Forms.Application.OpenForms)
                {
                    if (form.Name == "FormMasterSheet")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormMasterSheet formMasterSheet = new FormMasterSheet();
                formMasterSheet.Show();
            }
        }

        private void buttonStandings_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((System.Windows.Forms.Application.OpenForms["FormStandings"] as FormStandings) != null)
            {
                // if it is then select the right form
                foreach (Form form in System.Windows.Forms.Application.OpenForms)
                {
                    if (form.Name == "FormStandings")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormStandings formStandings = new FormStandings();
                formStandings.Show();
            }
        }

        private void buttonMasterSeason_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((System.Windows.Forms.Application.OpenForms["FormMasterSeason"] as FormMasterSeason) != null)
            {
                // if it is then select the right form
                foreach (Form form in System.Windows.Forms.Application.OpenForms)
                {
                    if (form.Name == "FormMasterSeason")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormMasterSeason formMasterSeason = new FormMasterSeason();
                formMasterSeason.Show();
            }
        }

        private void CreateExcelPacket()
        {
            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            string filename = "default_filename";

            // if there is a season selected then create the file name
            if (PublicVariables.GetDefaultSeason != null)
            {
                filename = "Football_Packet_" + PublicVariables.GetDefaultSeason;
            }

            // create the excel application
            Microsoft.Office.Interop.Excel.Application MyExcel = new Microsoft.Office.Interop.Excel.Application();
            // create the workbook
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = MyExcel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            // create the worksheets
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek01;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek02;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek03;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek04;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek05;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek06;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek07;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek08;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek09;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek10;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek11;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek12;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek13;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek14;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek15;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek16;
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek17;
            MyWorksheetWeek02 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek03 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek04 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek05 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek06 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek07 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek08 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek09 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek10 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek11 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek12 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek13 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek14 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek15 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek16 = MyWorkbook.Worksheets.Add();
            MyWorksheetWeek17 = MyWorkbook.Worksheets.Add();

            // create the cells
            Microsoft.Office.Interop.Excel.Range MyCells;

            MyExcel.StandardFont = "Arial";
            MyExcel.StandardFontSize = 12;

            progressBarCreatePacket.PerformStep();

            // -------------------------------------------  Week 01 -------------------------------------//
            // access the week 1 worksheet
            MyWorksheetWeek01 = MyExcel.Worksheets.Item[1];
            // name it for the tab at the bottom
            MyWorksheetWeek01.Name = "Week 1";
            // set the column widths to match moms
            MyWorksheetWeek01.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek01.Columns[i].ColumnWidth = 6.57;
            }           
            // access the cells
            MyCells = MyWorksheetWeek01.Cells;

            // align all the number cells
            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // The week goes in top right corner
            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 1";
            // due date goes right under it
            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek01;

            // Header where she enters thhe NFL FOOTBALL - DAY - DATE
            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            //  Visitor and Home at the top
            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            // Most commonly monday games
            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team01) ? "" : season1_5.Week01Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team02) ? "" : season1_5.Week01Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            // Header where she enters thhe NFL FOOTBALL - DAY - DATE
            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            // USUALLY 3 COLLEGE GAMES HERE
            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team03) ? "" : season1_5.Week01Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team04) ? "" : season1_5.Week01Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team05) ? "" : season1_5.Week01Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team06) ? "" : season1_5.Week01Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team07) ? "" : season1_5.Week01Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team08) ? "" : season1_5.Week01Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            // Header where she enters thhe NFL FOOTBALL - DAY - DATE
            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            // 13 SUNDAY GAMES HERE
            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team09) ? "" : season1_5.Week01Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team10) ? "" : season1_5.Week01Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team11) ? "" : season1_5.Week01Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team12) ? "" : season1_5.Week01Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team13) ? "" : season1_5.Week01Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team14) ? "" : season1_5.Week01Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team15) ? "" : season1_5.Week01Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team16) ? "" : season1_5.Week01Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team17) ? "" : season1_5.Week01Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team18) ? "" : season1_5.Week01Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team19) ? "" : season1_5.Week01Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team20) ? "" : season1_5.Week01Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team21) ? "" : season1_5.Week01Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team22) ? "" : season1_5.Week01Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team23) ? "" : season1_5.Week01Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team24) ? "" : season1_5.Week01Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team25) ? "" : season1_5.Week01Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team26) ? "" : season1_5.Week01Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team27) ? "" : season1_5.Week01Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team28) ? "" : season1_5.Week01Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team29) ? "" : season1_5.Week01Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team30) ? "" : season1_5.Week01Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team31) ? "" : season1_5.Week01Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team32) ? "" : season1_5.Week01Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team33) ? "" : season1_5.Week01Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team34) ? "" : season1_5.Week01Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            // Header where she enters thhe NFL FOOTBALL - DAY - DATE
            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            // USUALLY one monday night game
            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team35) ? "" : season1_5.Week01Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team36) ? "" : season1_5.Week01Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            // Header Pick 8 of 8 winners
            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            // Header Pick 8 of 8 winners
            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            //build the boxes where they enter the picks here
            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            // All leftover teams go here
            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team37) ? "" : season1_5.Week01Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team38) ? "" : season1_5.Week01Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team39) ? "" : season1_5.Week01Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team40) ? "" : season1_5.Week01Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team41) ? "" : season1_5.Week01Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team42) ? "" : season1_5.Week01Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season1_5.Week01Team43) ? "" : season1_5.Week01Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season1_5.Week01Team44) ? "" : season1_5.Week01Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------- Week 02 -------------------------------------//

            MyWorksheetWeek02 = MyExcel.Worksheets.Item[2];

            MyWorksheetWeek02.Name = "Week 02";

            MyWorksheetWeek02.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek02.Columns[i].ColumnWidth = 6.57;
            }
            
            MyCells = MyWorksheetWeek02.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 02";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek02;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team01) ? "" : season1_5.Week02Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team02) ? "" : season1_5.Week02Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team03) ? "" : season1_5.Week02Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team04) ? "" : season1_5.Week02Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team05) ? "" : season1_5.Week02Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team06) ? "" : season1_5.Week02Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team07) ? "" : season1_5.Week02Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team08) ? "" : season1_5.Week02Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team09) ? "" : season1_5.Week02Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team10) ? "" : season1_5.Week02Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team11) ? "" : season1_5.Week02Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team12) ? "" : season1_5.Week02Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team13) ? "" : season1_5.Week02Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team14) ? "" : season1_5.Week02Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team15) ? "" : season1_5.Week02Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team16) ? "" : season1_5.Week02Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team17) ? "" : season1_5.Week02Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team18) ? "" : season1_5.Week02Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team19) ? "" : season1_5.Week02Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team20) ? "" : season1_5.Week02Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team21) ? "" : season1_5.Week02Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team22) ? "" : season1_5.Week02Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team23) ? "" : season1_5.Week02Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team24) ? "" : season1_5.Week02Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team25) ? "" : season1_5.Week02Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team26) ? "" : season1_5.Week02Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team27) ? "" : season1_5.Week02Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team28) ? "" : season1_5.Week02Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team29) ? "" : season1_5.Week02Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team30) ? "" : season1_5.Week02Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team31) ? "" : season1_5.Week02Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team32) ? "" : season1_5.Week02Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team33) ? "" : season1_5.Week02Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team34) ? "" : season1_5.Week02Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team35) ? "" : season1_5.Week02Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team36) ? "" : season1_5.Week02Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team37) ? "" : season1_5.Week02Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team38) ? "" : season1_5.Week02Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team39) ? "" : season1_5.Week02Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team40) ? "" : season1_5.Week02Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team41) ? "" : season1_5.Week02Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team42) ? "" : season1_5.Week02Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season1_5.Week02Team43) ? "" : season1_5.Week02Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season1_5.Week02Team44) ? "" : season1_5.Week02Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // --------------------------------------------------- Week 03 -------------------------------------------------//
            MyWorksheetWeek03 = MyExcel.Worksheets.Item[3];

            MyWorksheetWeek03.Name = "Week 03";

            MyWorksheetWeek03.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek03.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek03.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 03";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek03;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team01) ? "" : season1_5.Week03Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team02) ? "" : season1_5.Week03Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team03) ? "" : season1_5.Week03Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team04) ? "" : season1_5.Week03Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team05) ? "" : season1_5.Week03Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team06) ? "" : season1_5.Week03Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team07) ? "" : season1_5.Week03Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team08) ? "" : season1_5.Week03Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team09) ? "" : season1_5.Week03Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team10) ? "" : season1_5.Week03Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team11) ? "" : season1_5.Week03Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team12) ? "" : season1_5.Week03Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team13) ? "" : season1_5.Week03Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team14) ? "" : season1_5.Week03Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team15) ? "" : season1_5.Week03Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team16) ? "" : season1_5.Week03Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team17) ? "" : season1_5.Week03Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team18) ? "" : season1_5.Week03Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team19) ? "" : season1_5.Week03Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team20) ? "" : season1_5.Week03Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team21) ? "" : season1_5.Week03Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team22) ? "" : season1_5.Week03Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team23) ? "" : season1_5.Week03Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team24) ? "" : season1_5.Week03Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team25) ? "" : season1_5.Week03Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team26) ? "" : season1_5.Week03Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team27) ? "" : season1_5.Week03Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team28) ? "" : season1_5.Week03Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team29) ? "" : season1_5.Week03Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team30) ? "" : season1_5.Week03Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team31) ? "" : season1_5.Week03Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team32) ? "" : season1_5.Week03Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team33) ? "" : season1_5.Week03Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team34) ? "" : season1_5.Week03Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team35) ? "" : season1_5.Week03Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team36) ? "" : season1_5.Week03Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team37) ? "" : season1_5.Week03Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team38) ? "" : season1_5.Week03Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team39) ? "" : season1_5.Week03Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team40) ? "" : season1_5.Week03Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team41) ? "" : season1_5.Week03Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team42) ? "" : season1_5.Week03Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season1_5.Week03Team43) ? "" : season1_5.Week03Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season1_5.Week03Team44) ? "" : season1_5.Week03Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // --------------------------------------------------- Week 04 -------------------------------------------------//
            MyWorksheetWeek04 = MyExcel.Worksheets.Item[4];

            MyWorksheetWeek04.Name = "Week 04";

            MyWorksheetWeek04.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek04.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek04.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 04";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek04;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team01) ? "" : season1_5.Week04Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team02) ? "" : season1_5.Week04Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team03) ? "" : season1_5.Week04Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team04) ? "" : season1_5.Week04Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team05) ? "" : season1_5.Week04Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team06) ? "" : season1_5.Week04Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team07) ? "" : season1_5.Week04Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team08) ? "" : season1_5.Week04Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team09) ? "" : season1_5.Week04Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team10) ? "" : season1_5.Week04Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team11) ? "" : season1_5.Week04Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team12) ? "" : season1_5.Week04Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team13) ? "" : season1_5.Week04Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team14) ? "" : season1_5.Week04Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team15) ? "" : season1_5.Week04Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team16) ? "" : season1_5.Week04Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team17) ? "" : season1_5.Week04Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team18) ? "" : season1_5.Week04Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team19) ? "" : season1_5.Week04Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team20) ? "" : season1_5.Week04Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team21) ? "" : season1_5.Week04Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team22) ? "" : season1_5.Week04Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team23) ? "" : season1_5.Week04Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team24) ? "" : season1_5.Week04Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team25) ? "" : season1_5.Week04Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team26) ? "" : season1_5.Week04Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team27) ? "" : season1_5.Week04Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team28) ? "" : season1_5.Week04Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team29) ? "" : season1_5.Week04Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team30) ? "" : season1_5.Week04Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team31) ? "" : season1_5.Week04Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team32) ? "" : season1_5.Week04Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team33) ? "" : season1_5.Week04Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team34) ? "" : season1_5.Week04Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team35) ? "" : season1_5.Week04Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team36) ? "" : season1_5.Week04Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team37) ? "" : season1_5.Week04Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team38) ? "" : season1_5.Week04Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team39) ? "" : season1_5.Week04Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team40) ? "" : season1_5.Week04Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team41) ? "" : season1_5.Week04Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team42) ? "" : season1_5.Week04Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season1_5.Week04Team43) ? "" : season1_5.Week04Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season1_5.Week04Team44) ? "" : season1_5.Week04Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // --------------------------------------------------- Week 05 -------------------------------------------------//
            MyWorksheetWeek05 = MyExcel.Worksheets.Item[5];

            MyWorksheetWeek05.Name = "Week 05";

            MyWorksheetWeek05.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek05.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek05.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 05";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek05;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team01) ? "" : season1_5.Week05Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team02) ? "" : season1_5.Week05Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team03) ? "" : season1_5.Week05Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team04) ? "" : season1_5.Week05Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team05) ? "" : season1_5.Week05Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team06) ? "" : season1_5.Week05Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team07) ? "" : season1_5.Week05Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team08) ? "" : season1_5.Week05Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team09) ? "" : season1_5.Week05Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team10) ? "" : season1_5.Week05Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team11) ? "" : season1_5.Week05Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team12) ? "" : season1_5.Week05Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team13) ? "" : season1_5.Week05Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team14) ? "" : season1_5.Week05Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team15) ? "" : season1_5.Week05Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team16) ? "" : season1_5.Week05Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team17) ? "" : season1_5.Week05Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team18) ? "" : season1_5.Week05Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team19) ? "" : season1_5.Week05Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team20) ? "" : season1_5.Week05Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team21) ? "" : season1_5.Week05Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team22) ? "" : season1_5.Week05Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team23) ? "" : season1_5.Week05Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team24) ? "" : season1_5.Week05Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team25) ? "" : season1_5.Week05Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team26) ? "" : season1_5.Week05Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team27) ? "" : season1_5.Week05Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team28) ? "" : season1_5.Week05Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team29) ? "" : season1_5.Week05Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team30) ? "" : season1_5.Week05Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team31) ? "" : season1_5.Week05Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team32) ? "" : season1_5.Week05Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team33) ? "" : season1_5.Week05Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team34) ? "" : season1_5.Week05Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team35) ? "" : season1_5.Week05Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team36) ? "" : season1_5.Week05Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team37) ? "" : season1_5.Week05Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team38) ? "" : season1_5.Week05Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team39) ? "" : season1_5.Week05Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team40) ? "" : season1_5.Week05Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team41) ? "" : season1_5.Week05Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team42) ? "" : season1_5.Week05Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season1_5.Week05Team43) ? "" : season1_5.Week05Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season1_5.Week05Team44) ? "" : season1_5.Week05Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // --------------------------------------------------- Week 06 -------------------------------------------------//
            MyWorksheetWeek06 = MyExcel.Worksheets.Item[6];

            MyWorksheetWeek06.Name = "Week 06";

            MyWorksheetWeek06.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek06.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek06.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 06";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek06;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team01) ? "" : season6_10.Week06Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team02) ? "" : season6_10.Week06Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team03) ? "" : season6_10.Week06Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team04) ? "" : season6_10.Week06Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team05) ? "" : season6_10.Week06Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team06) ? "" : season6_10.Week06Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team07) ? "" : season6_10.Week06Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team08) ? "" : season6_10.Week06Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team09) ? "" : season6_10.Week06Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team10) ? "" : season6_10.Week06Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team11) ? "" : season6_10.Week06Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team12) ? "" : season6_10.Week06Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team13) ? "" : season6_10.Week06Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team14) ? "" : season6_10.Week06Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team15) ? "" : season6_10.Week06Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team16) ? "" : season6_10.Week06Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team17) ? "" : season6_10.Week06Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team18) ? "" : season6_10.Week06Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team19) ? "" : season6_10.Week06Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team20) ? "" : season6_10.Week06Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team21) ? "" : season6_10.Week06Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team22) ? "" : season6_10.Week06Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team23) ? "" : season6_10.Week06Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team24) ? "" : season6_10.Week06Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team25) ? "" : season6_10.Week06Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team26) ? "" : season6_10.Week06Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team27) ? "" : season6_10.Week06Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team28) ? "" : season6_10.Week06Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team29) ? "" : season6_10.Week06Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team30) ? "" : season6_10.Week06Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team31) ? "" : season6_10.Week06Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team32) ? "" : season6_10.Week06Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team33) ? "" : season6_10.Week06Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team34) ? "" : season6_10.Week06Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team35) ? "" : season6_10.Week06Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team36) ? "" : season6_10.Week06Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team37) ? "" : season6_10.Week06Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team38) ? "" : season6_10.Week06Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team39) ? "" : season6_10.Week06Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team40) ? "" : season6_10.Week06Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team41) ? "" : season6_10.Week06Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team42) ? "" : season6_10.Week06Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season6_10.Week06Team43) ? "" : season6_10.Week06Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season6_10.Week06Team44) ? "" : season6_10.Week06Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 07 --------------------------------------------//

            MyWorksheetWeek07 = MyExcel.Worksheets.Item[7];

            MyWorksheetWeek07.Name = "Week 07";

            MyWorksheetWeek07.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek07.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek07.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 07";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek07;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team01) ? "" : season6_10.Week07Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team02) ? "" : season6_10.Week07Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team03) ? "" : season6_10.Week07Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team04) ? "" : season6_10.Week07Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team05) ? "" : season6_10.Week07Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team06) ? "" : season6_10.Week07Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team07) ? "" : season6_10.Week07Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team08) ? "" : season6_10.Week07Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team09) ? "" : season6_10.Week07Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team10) ? "" : season6_10.Week07Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team11) ? "" : season6_10.Week07Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team12) ? "" : season6_10.Week07Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team13) ? "" : season6_10.Week07Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team14) ? "" : season6_10.Week07Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team15) ? "" : season6_10.Week07Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team16) ? "" : season6_10.Week07Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team17) ? "" : season6_10.Week07Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team18) ? "" : season6_10.Week07Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team19) ? "" : season6_10.Week07Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team20) ? "" : season6_10.Week07Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team21) ? "" : season6_10.Week07Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team22) ? "" : season6_10.Week07Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team23) ? "" : season6_10.Week07Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team24) ? "" : season6_10.Week07Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team25) ? "" : season6_10.Week07Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team26) ? "" : season6_10.Week07Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team27) ? "" : season6_10.Week07Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team28) ? "" : season6_10.Week07Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team29) ? "" : season6_10.Week07Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team30) ? "" : season6_10.Week07Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team31) ? "" : season6_10.Week07Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team32) ? "" : season6_10.Week07Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team33) ? "" : season6_10.Week07Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team34) ? "" : season6_10.Week07Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team35) ? "" : season6_10.Week07Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team36) ? "" : season6_10.Week07Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team37) ? "" : season6_10.Week07Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team38) ? "" : season6_10.Week07Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team39) ? "" : season6_10.Week07Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team40) ? "" : season6_10.Week07Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team41) ? "" : season6_10.Week07Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team42) ? "" : season6_10.Week07Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season6_10.Week07Team43) ? "" : season6_10.Week07Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season6_10.Week07Team44) ? "" : season6_10.Week07Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 08 --------------------------------------------//

            MyWorksheetWeek08 = MyExcel.Worksheets.Item[8];

            MyWorksheetWeek08.Name = "Week 08";

            MyWorksheetWeek08.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek08.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek08.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 08";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek08;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team01) ? "" : season6_10.Week08Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team02) ? "" : season6_10.Week08Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team03) ? "" : season6_10.Week08Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team04) ? "" : season6_10.Week08Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team05) ? "" : season6_10.Week08Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team06) ? "" : season6_10.Week08Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team07) ? "" : season6_10.Week08Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team08) ? "" : season6_10.Week08Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team09) ? "" : season6_10.Week08Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team10) ? "" : season6_10.Week08Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team11) ? "" : season6_10.Week08Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team12) ? "" : season6_10.Week08Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team13) ? "" : season6_10.Week08Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team14) ? "" : season6_10.Week08Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team15) ? "" : season6_10.Week08Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team16) ? "" : season6_10.Week08Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team17) ? "" : season6_10.Week08Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team18) ? "" : season6_10.Week08Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team19) ? "" : season6_10.Week08Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team20) ? "" : season6_10.Week08Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team21) ? "" : season6_10.Week08Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team22) ? "" : season6_10.Week08Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team23) ? "" : season6_10.Week08Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team24) ? "" : season6_10.Week08Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team25) ? "" : season6_10.Week08Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team26) ? "" : season6_10.Week08Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team27) ? "" : season6_10.Week08Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team28) ? "" : season6_10.Week08Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team29) ? "" : season6_10.Week08Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team30) ? "" : season6_10.Week08Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team31) ? "" : season6_10.Week08Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team32) ? "" : season6_10.Week08Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team33) ? "" : season6_10.Week08Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team34) ? "" : season6_10.Week08Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team35) ? "" : season6_10.Week08Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team36) ? "" : season6_10.Week08Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team37) ? "" : season6_10.Week08Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team38) ? "" : season6_10.Week08Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team39) ? "" : season6_10.Week08Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team40) ? "" : season6_10.Week08Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team41) ? "" : season6_10.Week08Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team42) ? "" : season6_10.Week08Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season6_10.Week08Team43) ? "" : season6_10.Week08Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season6_10.Week08Team44) ? "" : season6_10.Week08Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 09 --------------------------------------------//

            MyWorksheetWeek09 = MyExcel.Worksheets.Item[9];

            MyWorksheetWeek09.Name = "Week 09";

            MyWorksheetWeek09.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek09.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek09.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 09";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek09;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team01) ? "" : season6_10.Week09Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team02) ? "" : season6_10.Week09Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team03) ? "" : season6_10.Week09Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team04) ? "" : season6_10.Week09Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team05) ? "" : season6_10.Week09Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team06) ? "" : season6_10.Week09Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team07) ? "" : season6_10.Week09Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team08) ? "" : season6_10.Week09Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team09) ? "" : season6_10.Week09Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team10) ? "" : season6_10.Week09Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team11) ? "" : season6_10.Week09Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team12) ? "" : season6_10.Week09Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team13) ? "" : season6_10.Week09Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team14) ? "" : season6_10.Week09Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team15) ? "" : season6_10.Week09Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team16) ? "" : season6_10.Week09Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team17) ? "" : season6_10.Week09Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team18) ? "" : season6_10.Week09Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team19) ? "" : season6_10.Week09Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team20) ? "" : season6_10.Week09Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team21) ? "" : season6_10.Week09Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team22) ? "" : season6_10.Week09Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team23) ? "" : season6_10.Week09Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team24) ? "" : season6_10.Week09Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team25) ? "" : season6_10.Week09Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team26) ? "" : season6_10.Week09Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team27) ? "" : season6_10.Week09Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team28) ? "" : season6_10.Week09Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team29) ? "" : season6_10.Week09Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team30) ? "" : season6_10.Week09Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team31) ? "" : season6_10.Week09Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team32) ? "" : season6_10.Week09Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team33) ? "" : season6_10.Week09Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team34) ? "" : season6_10.Week09Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team35) ? "" : season6_10.Week09Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team36) ? "" : season6_10.Week09Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team37) ? "" : season6_10.Week09Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team38) ? "" : season6_10.Week09Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team39) ? "" : season6_10.Week09Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team40) ? "" : season6_10.Week09Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team41) ? "" : season6_10.Week09Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team42) ? "" : season6_10.Week09Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season6_10.Week09Team43) ? "" : season6_10.Week09Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season6_10.Week09Team44) ? "" : season6_10.Week09Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 10 --------------------------------------------//

            MyWorksheetWeek10 = MyExcel.Worksheets.Item[10];

            MyWorksheetWeek10.Name = "Week 10";

            MyWorksheetWeek10.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek10.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek10.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 10";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek10;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team01) ? "" : season6_10.Week10Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team02) ? "" : season6_10.Week10Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team03) ? "" : season6_10.Week10Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team04) ? "" : season6_10.Week10Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team05) ? "" : season6_10.Week10Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team06) ? "" : season6_10.Week10Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team07) ? "" : season6_10.Week10Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team08) ? "" : season6_10.Week10Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team09) ? "" : season6_10.Week10Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team10) ? "" : season6_10.Week10Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team11) ? "" : season6_10.Week10Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team12) ? "" : season6_10.Week10Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team13) ? "" : season6_10.Week10Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team14) ? "" : season6_10.Week10Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team15) ? "" : season6_10.Week10Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team16) ? "" : season6_10.Week10Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team17) ? "" : season6_10.Week10Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team18) ? "" : season6_10.Week10Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team19) ? "" : season6_10.Week10Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team20) ? "" : season6_10.Week10Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team21) ? "" : season6_10.Week10Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team22) ? "" : season6_10.Week10Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team23) ? "" : season6_10.Week10Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team24) ? "" : season6_10.Week10Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team25) ? "" : season6_10.Week10Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team26) ? "" : season6_10.Week10Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team27) ? "" : season6_10.Week10Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team28) ? "" : season6_10.Week10Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team29) ? "" : season6_10.Week10Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team30) ? "" : season6_10.Week10Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team31) ? "" : season6_10.Week10Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team32) ? "" : season6_10.Week10Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team33) ? "" : season6_10.Week10Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team34) ? "" : season6_10.Week10Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team35) ? "" : season6_10.Week10Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team36) ? "" : season6_10.Week10Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team37) ? "" : season6_10.Week10Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team38) ? "" : season6_10.Week10Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team39) ? "" : season6_10.Week10Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team40) ? "" : season6_10.Week10Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team41) ? "" : season6_10.Week10Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team42) ? "" : season6_10.Week10Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season6_10.Week10Team43) ? "" : season6_10.Week10Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season6_10.Week10Team44) ? "" : season6_10.Week10Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 11 --------------------------------------------//

            MyWorksheetWeek11 = MyExcel.Worksheets.Item[11];

            MyWorksheetWeek11.Name = "Week 11";

            MyWorksheetWeek11.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek11.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek11.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 11";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek11;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team01) ? "" : season11_17.Week11Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team02) ? "" : season11_17.Week11Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team03) ? "" : season11_17.Week11Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team04) ? "" : season11_17.Week11Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team05) ? "" : season11_17.Week11Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team06) ? "" : season11_17.Week11Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team07) ? "" : season11_17.Week11Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team08) ? "" : season11_17.Week11Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team09) ? "" : season11_17.Week11Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team10) ? "" : season11_17.Week11Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team11) ? "" : season11_17.Week11Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team12) ? "" : season11_17.Week11Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team13) ? "" : season11_17.Week11Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team14) ? "" : season11_17.Week11Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team15) ? "" : season11_17.Week11Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team16) ? "" : season11_17.Week11Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team17) ? "" : season11_17.Week11Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team18) ? "" : season11_17.Week11Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team19) ? "" : season11_17.Week11Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team20) ? "" : season11_17.Week11Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team21) ? "" : season11_17.Week11Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team22) ? "" : season11_17.Week11Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team23) ? "" : season11_17.Week11Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team24) ? "" : season11_17.Week11Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team25) ? "" : season11_17.Week11Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team26) ? "" : season11_17.Week11Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team27) ? "" : season11_17.Week11Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team28) ? "" : season11_17.Week11Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team29) ? "" : season11_17.Week11Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team30) ? "" : season11_17.Week11Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team31) ? "" : season11_17.Week11Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team32) ? "" : season11_17.Week11Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team33) ? "" : season11_17.Week11Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team34) ? "" : season11_17.Week11Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team35) ? "" : season11_17.Week11Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team36) ? "" : season11_17.Week11Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team37) ? "" : season11_17.Week11Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team38) ? "" : season11_17.Week11Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team39) ? "" : season11_17.Week11Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team40) ? "" : season11_17.Week11Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team41) ? "" : season11_17.Week11Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team42) ? "" : season11_17.Week11Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week11Team43) ? "" : season11_17.Week11Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week11Team44) ? "" : season11_17.Week11Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 12 --------------------------------------------//

            MyWorksheetWeek12 = MyExcel.Worksheets.Item[12];

            MyWorksheetWeek12.Name = "Week 12";

            MyWorksheetWeek12.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek12.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek12.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 12";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek12;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team01) ? "" : season11_17.Week12Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team02) ? "" : season11_17.Week12Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team03) ? "" : season11_17.Week12Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team04) ? "" : season11_17.Week12Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team05) ? "" : season11_17.Week12Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team06) ? "" : season11_17.Week12Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team07) ? "" : season11_17.Week12Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team08) ? "" : season11_17.Week12Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team09) ? "" : season11_17.Week12Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team10) ? "" : season11_17.Week12Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team11) ? "" : season11_17.Week12Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team12) ? "" : season11_17.Week12Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team13) ? "" : season11_17.Week12Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team14) ? "" : season11_17.Week12Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team15) ? "" : season11_17.Week12Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team16) ? "" : season11_17.Week12Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team17) ? "" : season11_17.Week12Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team18) ? "" : season11_17.Week12Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team19) ? "" : season11_17.Week12Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team20) ? "" : season11_17.Week12Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team21) ? "" : season11_17.Week12Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team22) ? "" : season11_17.Week12Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team23) ? "" : season11_17.Week12Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team24) ? "" : season11_17.Week12Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team25) ? "" : season11_17.Week12Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team26) ? "" : season11_17.Week12Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team27) ? "" : season11_17.Week12Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team28) ? "" : season11_17.Week12Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team29) ? "" : season11_17.Week12Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team30) ? "" : season11_17.Week12Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team31) ? "" : season11_17.Week12Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team32) ? "" : season11_17.Week12Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team33) ? "" : season11_17.Week12Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team34) ? "" : season11_17.Week12Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team35) ? "" : season11_17.Week12Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team36) ? "" : season11_17.Week12Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team37) ? "" : season11_17.Week12Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team38) ? "" : season11_17.Week12Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team39) ? "" : season11_17.Week12Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team40) ? "" : season11_17.Week12Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team41) ? "" : season11_17.Week12Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team42) ? "" : season11_17.Week12Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week12Team43) ? "" : season11_17.Week12Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week12Team44) ? "" : season11_17.Week12Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 13 --------------------------------------------//

            MyWorksheetWeek13 = MyExcel.Worksheets.Item[13];

            MyWorksheetWeek13.Name = "Week 13";

            MyWorksheetWeek13.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek13.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek13.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 13";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek13;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team01) ? "" : season11_17.Week13Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team02) ? "" : season11_17.Week13Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team03) ? "" : season11_17.Week13Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team04) ? "" : season11_17.Week13Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team05) ? "" : season11_17.Week13Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team06) ? "" : season11_17.Week13Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team07) ? "" : season11_17.Week13Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team08) ? "" : season11_17.Week13Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team09) ? "" : season11_17.Week13Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team10) ? "" : season11_17.Week13Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team11) ? "" : season11_17.Week13Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team12) ? "" : season11_17.Week13Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team13) ? "" : season11_17.Week13Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team14) ? "" : season11_17.Week13Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team15) ? "" : season11_17.Week13Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team16) ? "" : season11_17.Week13Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team17) ? "" : season11_17.Week13Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team18) ? "" : season11_17.Week13Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team19) ? "" : season11_17.Week13Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team20) ? "" : season11_17.Week13Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team21) ? "" : season11_17.Week13Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team22) ? "" : season11_17.Week13Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team23) ? "" : season11_17.Week13Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team24) ? "" : season11_17.Week13Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team25) ? "" : season11_17.Week13Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team26) ? "" : season11_17.Week13Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team27) ? "" : season11_17.Week13Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team28) ? "" : season11_17.Week13Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team29) ? "" : season11_17.Week13Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team30) ? "" : season11_17.Week13Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team31) ? "" : season11_17.Week13Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team32) ? "" : season11_17.Week13Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team33) ? "" : season11_17.Week13Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team34) ? "" : season11_17.Week13Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team35) ? "" : season11_17.Week13Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team36) ? "" : season11_17.Week13Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team37) ? "" : season11_17.Week13Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team38) ? "" : season11_17.Week13Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team39) ? "" : season11_17.Week13Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team40) ? "" : season11_17.Week13Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team41) ? "" : season11_17.Week13Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team42) ? "" : season11_17.Week13Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week13Team43) ? "" : season11_17.Week13Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week13Team44) ? "" : season11_17.Week13Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 14 --------------------------------------------//

            MyWorksheetWeek14 = MyExcel.Worksheets.Item[14];

            MyWorksheetWeek14.Name = "Week 14";

            MyWorksheetWeek14.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek14.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek14.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 14";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek14;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team01) ? "" : season11_17.Week14Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team02) ? "" : season11_17.Week14Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team03) ? "" : season11_17.Week14Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team04) ? "" : season11_17.Week14Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team05) ? "" : season11_17.Week14Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team06) ? "" : season11_17.Week14Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team07) ? "" : season11_17.Week14Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team08) ? "" : season11_17.Week14Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team09) ? "" : season11_17.Week14Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team10) ? "" : season11_17.Week14Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team11) ? "" : season11_17.Week14Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team12) ? "" : season11_17.Week14Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team13) ? "" : season11_17.Week14Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team14) ? "" : season11_17.Week14Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team15) ? "" : season11_17.Week14Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team16) ? "" : season11_17.Week14Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team17) ? "" : season11_17.Week14Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team18) ? "" : season11_17.Week14Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team19) ? "" : season11_17.Week14Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team20) ? "" : season11_17.Week14Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team21) ? "" : season11_17.Week14Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team22) ? "" : season11_17.Week14Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team23) ? "" : season11_17.Week14Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team24) ? "" : season11_17.Week14Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team25) ? "" : season11_17.Week14Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team26) ? "" : season11_17.Week14Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team27) ? "" : season11_17.Week14Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team28) ? "" : season11_17.Week14Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team29) ? "" : season11_17.Week14Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team30) ? "" : season11_17.Week14Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team31) ? "" : season11_17.Week14Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team32) ? "" : season11_17.Week14Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team33) ? "" : season11_17.Week14Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team34) ? "" : season11_17.Week14Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team35) ? "" : season11_17.Week14Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team36) ? "" : season11_17.Week14Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team37) ? "" : season11_17.Week14Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team38) ? "" : season11_17.Week14Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team39) ? "" : season11_17.Week14Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team40) ? "" : season11_17.Week14Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team41) ? "" : season11_17.Week14Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team42) ? "" : season11_17.Week14Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week14Team43) ? "" : season11_17.Week14Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week14Team44) ? "" : season11_17.Week14Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 15 --------------------------------------------//

            MyWorksheetWeek15 = MyExcel.Worksheets.Item[15];

            MyWorksheetWeek15.Name = "Week 15";

            MyWorksheetWeek15.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek15.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek15.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 15";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek15;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team01) ? "" : season11_17.Week15Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team02) ? "" : season11_17.Week15Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team03) ? "" : season11_17.Week15Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team04) ? "" : season11_17.Week15Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team05) ? "" : season11_17.Week15Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team06) ? "" : season11_17.Week15Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team07) ? "" : season11_17.Week15Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team08) ? "" : season11_17.Week15Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team09) ? "" : season11_17.Week15Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team10) ? "" : season11_17.Week15Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team11) ? "" : season11_17.Week15Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team12) ? "" : season11_17.Week15Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team13) ? "" : season11_17.Week15Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team14) ? "" : season11_17.Week15Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team15) ? "" : season11_17.Week15Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team16) ? "" : season11_17.Week15Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team17) ? "" : season11_17.Week15Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team18) ? "" : season11_17.Week15Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team19) ? "" : season11_17.Week15Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team20) ? "" : season11_17.Week15Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team21) ? "" : season11_17.Week15Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team22) ? "" : season11_17.Week15Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team23) ? "" : season11_17.Week15Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team24) ? "" : season11_17.Week15Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team25) ? "" : season11_17.Week15Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team26) ? "" : season11_17.Week15Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team27) ? "" : season11_17.Week15Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team28) ? "" : season11_17.Week15Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team29) ? "" : season11_17.Week15Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team30) ? "" : season11_17.Week15Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team31) ? "" : season11_17.Week15Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team32) ? "" : season11_17.Week15Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team33) ? "" : season11_17.Week15Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team34) ? "" : season11_17.Week15Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team35) ? "" : season11_17.Week15Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team36) ? "" : season11_17.Week15Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team37) ? "" : season11_17.Week15Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team38) ? "" : season11_17.Week15Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team39) ? "" : season11_17.Week15Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team40) ? "" : season11_17.Week15Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team41) ? "" : season11_17.Week15Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team42) ? "" : season11_17.Week15Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week15Team43) ? "" : season11_17.Week15Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week15Team44) ? "" : season11_17.Week15Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 16 --------------------------------------------//

            MyWorksheetWeek16 = MyExcel.Worksheets.Item[16];

            MyWorksheetWeek16.Name = "Week 16";

            MyWorksheetWeek16.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek16.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek16.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 16";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek16;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team01) ? "" : season11_17.Week16Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team02) ? "" : season11_17.Week16Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team03) ? "" : season11_17.Week16Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team04) ? "" : season11_17.Week16Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team05) ? "" : season11_17.Week16Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team06) ? "" : season11_17.Week16Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team07) ? "" : season11_17.Week16Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team08) ? "" : season11_17.Week16Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team09) ? "" : season11_17.Week16Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team10) ? "" : season11_17.Week16Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team11) ? "" : season11_17.Week16Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team12) ? "" : season11_17.Week16Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team13) ? "" : season11_17.Week16Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team14) ? "" : season11_17.Week16Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team15) ? "" : season11_17.Week16Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team16) ? "" : season11_17.Week16Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team17) ? "" : season11_17.Week16Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team18) ? "" : season11_17.Week16Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team19) ? "" : season11_17.Week16Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team20) ? "" : season11_17.Week16Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team21) ? "" : season11_17.Week16Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team22) ? "" : season11_17.Week16Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team23) ? "" : season11_17.Week16Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team24) ? "" : season11_17.Week16Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team25) ? "" : season11_17.Week16Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team26) ? "" : season11_17.Week16Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team27) ? "" : season11_17.Week16Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team28) ? "" : season11_17.Week16Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team29) ? "" : season11_17.Week16Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team30) ? "" : season11_17.Week16Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team31) ? "" : season11_17.Week16Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team32) ? "" : season11_17.Week16Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team33) ? "" : season11_17.Week16Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team34) ? "" : season11_17.Week16Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team35) ? "" : season11_17.Week16Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team36) ? "" : season11_17.Week16Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team37) ? "" : season11_17.Week16Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team38) ? "" : season11_17.Week16Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team39) ? "" : season11_17.Week16Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team40) ? "" : season11_17.Week16Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team41) ? "" : season11_17.Week16Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team42) ? "" : season11_17.Week16Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week16Team43) ? "" : season11_17.Week16Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week16Team44) ? "" : season11_17.Week16Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // ------------------------------------------------------------ Week 17 --------------------------------------------//

            MyWorksheetWeek17 = MyExcel.Worksheets.Item[17];

            MyWorksheetWeek17.Name = "Week 17";

            MyWorksheetWeek17.Rows[41].RowHeight = 45;
            for (int i = 1; i <= 10; i++)
            {
                MyWorksheetWeek17.Columns[i].ColumnWidth = 6.57;
            }

            MyCells = MyWorksheetWeek17.Cells;

            MyCells.Range["B8:B46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            MyCells.Range["F8:F46"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            MyCells[1, "J"].Font.Bold = true;
            MyCells.Item[1, "J"].Value = "WEEK 17";

            MyCells[2, "J"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            MyCells[2, "J"].Font.Size = 10;
            MyCells[2, "J"].Value = "( due date goes here )";

            MyCells.Item[1, "A"].Font.Size = 9;
            MyCells.Item[1, "A"].Font.Italic = true;
            MyCells.Item[1, "A"].value = byeTeamsWeek17;

            MyCells.Item[4, "A"].Font.Bold = true;
            MyCells.Item[4, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY THURSDAY GAME";

            MyCells.Item[6, "C"].Font.Bold = true;
            MyCells.Item[6, "C"].Value = "VISITOR";
            MyCells.Item[6, "G"].Font.Bold = true;
            MyCells.Item[6, "G"].Value = "HOME";

            MyCells.Item[8, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team01) ? "" : season11_17.Week17Team01.Substring(2).Trim(); MyCells.Item[8, "B"].Value = "1";
            MyCells.Item[8, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team02) ? "" : season11_17.Week17Team02.Substring(2).Trim(); MyCells.Item[8, "F"].Value = "2";

            MyCells.Item[10, "A"].Font.Bold = true;
            MyCells.Item[10, "A"].Value = "ENTER LEAGUE & DATE MOST LIKELY COLLEGE GAMES";

            MyCells.Item[12, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team03) ? "" : season11_17.Week17Team03.Substring(2).Trim(); MyCells.Item[12, "B"].Value = "3";
            MyCells.Item[12, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team04) ? "" : season11_17.Week17Team04.Substring(2).Trim(); MyCells.Item[12, "F"].Value = "4";
            MyCells.Item[13, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team05) ? "" : season11_17.Week17Team05.Substring(2).Trim(); MyCells.Item[13, "B"].Value = "5";
            MyCells.Item[13, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team06) ? "" : season11_17.Week17Team06.Substring(2).Trim(); MyCells.Item[13, "F"].Value = "6";
            MyCells.Item[14, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team07) ? "" : season11_17.Week17Team07.Substring(2).Trim(); MyCells.Item[14, "B"].Value = "7";
            MyCells.Item[14, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team08) ? "" : season11_17.Week17Team08.Substring(2).Trim(); MyCells.Item[14, "F"].Value = "8";

            MyCells.Item[16, "A"].Font.Bold = true;
            MyCells.Item[16, "A"].Value = "SUNDAY GAMES SHOULD MOSTLY GO HERE";

            MyCells.Item[18, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team09) ? "" : season11_17.Week17Team09.Substring(2).Trim(); MyCells.Item[18, "B"].Value = "9";
            MyCells.Item[18, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team10) ? "" : season11_17.Week17Team10.Substring(2).Trim(); MyCells.Item[18, "F"].Value = "10";
            MyCells.Item[19, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team11) ? "" : season11_17.Week17Team11.Substring(2).Trim(); MyCells.Item[19, "B"].Value = "11";
            MyCells.Item[19, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team12) ? "" : season11_17.Week17Team12.Substring(2).Trim(); MyCells.Item[19, "F"].Value = "12";
            MyCells.Item[20, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team13) ? "" : season11_17.Week17Team13.Substring(2).Trim(); MyCells.Item[20, "B"].Value = "13";
            MyCells.Item[20, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team14) ? "" : season11_17.Week17Team14.Substring(2).Trim(); MyCells.Item[20, "F"].Value = "14";
            MyCells.Item[21, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team15) ? "" : season11_17.Week17Team15.Substring(2).Trim(); MyCells.Item[21, "B"].Value = "15";
            MyCells.Item[21, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team16) ? "" : season11_17.Week17Team16.Substring(2).Trim(); MyCells.Item[21, "F"].Value = "16";
            MyCells.Item[22, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team17) ? "" : season11_17.Week17Team17.Substring(2).Trim(); MyCells.Item[22, "B"].Value = "17";
            MyCells.Item[22, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team18) ? "" : season11_17.Week17Team18.Substring(2).Trim(); MyCells.Item[22, "F"].Value = "18";
            MyCells.Item[23, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team19) ? "" : season11_17.Week17Team19.Substring(2).Trim(); MyCells.Item[23, "B"].Value = "19";
            MyCells.Item[23, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team20) ? "" : season11_17.Week17Team20.Substring(2).Trim(); MyCells.Item[23, "F"].Value = "20";
            MyCells.Item[24, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team21) ? "" : season11_17.Week17Team21.Substring(2).Trim(); MyCells.Item[24, "B"].Value = "21";
            MyCells.Item[24, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team22) ? "" : season11_17.Week17Team22.Substring(2).Trim(); MyCells.Item[24, "F"].Value = "22";
            MyCells.Item[25, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team23) ? "" : season11_17.Week17Team23.Substring(2).Trim(); MyCells.Item[25, "B"].Value = "23";
            MyCells.Item[25, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team24) ? "" : season11_17.Week17Team24.Substring(2).Trim(); MyCells.Item[25, "F"].Value = "24";
            MyCells.Item[26, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team25) ? "" : season11_17.Week17Team25.Substring(2).Trim(); MyCells.Item[26, "B"].Value = "25";
            MyCells.Item[26, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team26) ? "" : season11_17.Week17Team26.Substring(2).Trim(); MyCells.Item[26, "F"].Value = "26";
            MyCells.Item[27, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team27) ? "" : season11_17.Week17Team27.Substring(2).Trim(); MyCells.Item[27, "B"].Value = "27";
            MyCells.Item[27, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team28) ? "" : season11_17.Week17Team28.Substring(2).Trim(); MyCells.Item[27, "F"].Value = "28";
            MyCells.Item[28, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team29) ? "" : season11_17.Week17Team29.Substring(2).Trim(); MyCells.Item[28, "B"].Value = "29";
            MyCells.Item[28, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team30) ? "" : season11_17.Week17Team30.Substring(2).Trim(); MyCells.Item[28, "F"].Value = "30";
            MyCells.Item[29, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team31) ? "" : season11_17.Week17Team31.Substring(2).Trim(); MyCells.Item[29, "B"].Value = "31";
            MyCells.Item[29, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team32) ? "" : season11_17.Week17Team32.Substring(2).Trim(); MyCells.Item[29, "F"].Value = "32";
            MyCells.Item[30, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team33) ? "" : season11_17.Week17Team33.Substring(2).Trim(); MyCells.Item[30, "B"].Value = "33";
            MyCells.Item[30, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team34) ? "" : season11_17.Week17Team34.Substring(2).Trim(); MyCells.Item[30, "F"].Value = "34";

            MyCells.Item[32, "A"].Font.Bold = true;
            MyCells.Item[32, "A"].Value = "MONDAY NIGHT GAME SHOULD GO HERE";

            MyCells.Item[34, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team35) ? "" : season11_17.Week17Team35.Substring(2).Trim(); MyCells.Item[34, "B"].Value = "35";
            MyCells.Item[34, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team36) ? "" : season11_17.Week17Team36.Substring(2).Trim(); MyCells.Item[34, "F"].Value = "36";

            MyCells.Item[36, "A"].Font.Bold = true;
            MyCells.Item[36, "A"].Value = "PICK 8 OF 8 WINNERS";

            MyCells.Item[38, "A"].Font.Bold = true;
            MyCells.Item[38, "A"].Value = "POOL NAME:__________________________________________";

            MyCells[41, "B"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "C"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "D"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "E"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "F"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "G"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "H"].Borders.Weight = XlBorderWeight.xlMedium;
            MyCells[41, "I"].Borders.Weight = XlBorderWeight.xlMedium;

            MyCells.Item[43, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team37) ? "" : season11_17.Week17Team37.Substring(2).Trim(); MyCells.Item[43, "B"].Value = "37";
            MyCells.Item[43, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team38) ? "" : season11_17.Week17Team38.Substring(2).Trim(); MyCells.Item[43, "F"].Value = "38";
            MyCells.Item[44, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team39) ? "" : season11_17.Week17Team39.Substring(2).Trim(); MyCells.Item[44, "B"].Value = "39";
            MyCells.Item[44, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team40) ? "" : season11_17.Week17Team40.Substring(2).Trim(); MyCells.Item[44, "F"].Value = "40";
            MyCells.Item[45, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team41) ? "" : season11_17.Week17Team41.Substring(2).Trim(); MyCells.Item[45, "B"].Value = "41";
            MyCells.Item[45, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team42) ? "" : season11_17.Week17Team42.Substring(2).Trim(); MyCells.Item[45, "F"].Value = "42";
            MyCells.Item[46, "C"].Value = String.IsNullOrEmpty(season11_17.Week17Team43) ? "" : season11_17.Week17Team43.Substring(2).Trim(); MyCells.Item[46, "B"].Value = "43";
            MyCells.Item[46, "G"].Value = String.IsNullOrEmpty(season11_17.Week17Team44) ? "" : season11_17.Week17Team44.Substring(2).Trim(); MyCells.Item[46, "F"].Value = "44";

            progressBarCreatePacket.PerformStep();

            // --------------------------------------------------- END SAVE THE EXCEL FILE ----------------------------------------///
            MyWorkbook.SaveAs(@"C:\Big8\" + filename + ".xls");

            progressBarCreatePacket.PerformStep();
            MessageBox.Show("File Created at: C:\\Big8" + Environment.NewLine + "Filename: " + filename);

            progressBarCreatePacket.Visible = false;
            MyExcel.Visible = true;            
        }

        private void seasons1_5BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.seasons1_5BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);

        }

        private void FormExcelSheets_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);

        }

        private void buttonCreatePacket_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            labelBuildingPacket.Visible = true;
            progressBarCreatePacket.Visible = true;
            CreateNFLTeamList();
            progressBarCreatePacket.PerformStep();
            PopulateWeekTeamLists();
            progressBarCreatePacket.PerformStep();
            GetByeWeekTeams();
            progressBarCreatePacket.PerformStep();
            CreateExcelPacket();
            labelBuildingPacket.Visible = false;
            progressBarCreatePacket.Visible = false;
            Cursor.Current = Cursors.Default;
        }

        private void GetByeWeekTeams()
        {
            // assign the season databases
            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            List<string> tempNFLTeamList = new List<string>();
            tempNFLTeamList = NFLTeamList.ToList();

            // find teams on bye week 01
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                // if the nfl team is playing then remove them from the temp list. Remaining teams are bye and will be added to the string
                if (Week01TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            // add the bye teams to their string
            for (int i = 0; i < tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek01 += ", " + tempNFLTeamList[i];
            }

            // find teams on bye week 02
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week02TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i < tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek02 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 03
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week03TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i < tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek03 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 04
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week04TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i < tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek04 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 05
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week05TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek05 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 06
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week06TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek06 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 07
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week07TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek07 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 08
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week08TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek08 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 09
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week09TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek09 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 10
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week10TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek10 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 11
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week11TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek11 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 12
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week12TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek12 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 13
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week13TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek13 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 14
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week14TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek14 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 15
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week15TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek15 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 16
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week16TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek16 += ", " + tempNFLTeamList[i];
            }
            // find teams on bye week 17
            tempNFLTeamList.Clear();
            tempNFLTeamList = NFLTeamList.ToList();
            for (int i = tempNFLTeamList.Count - 1; i >= 0; i--)
            {
                if (Week17TeamsList.Contains(tempNFLTeamList[i]))
                {
                    tempNFLTeamList.RemoveAt(i);
                }
            }
            for (int i = 0; i<tempNFLTeamList.Count; i++)
            {
                byeTeamsWeek17 += ", " + tempNFLTeamList[i];
            }
}

        private void PopulateWeekTeamLists()
        {
            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            // clear the lists
            Week01TeamsList.Clear();
            Week02TeamsList.Clear();
            Week03TeamsList.Clear();
            Week04TeamsList.Clear();
            Week05TeamsList.Clear();
            Week06TeamsList.Clear();
            Week07TeamsList.Clear();
            Week08TeamsList.Clear();
            Week09TeamsList.Clear();
            Week10TeamsList.Clear();
            Week11TeamsList.Clear();
            Week12TeamsList.Clear();
            Week13TeamsList.Clear();
            Week14TeamsList.Clear();
            Week15TeamsList.Clear();
            Week16TeamsList.Clear();
            Week17TeamsList.Clear();

            // ------------------- WEEK 01 -------------------------
            if (season1_5.Week01Team01 != "")
            {
                for (int i = 1; i <= 44; i++)
                {
                    // textbox list index starts at 0 and the database index starts at 1 and changes based on where i am accessing it. [i-1] brings the list index down to zero while the
                    // database index will continue from 1-220. Checks if the string is also null because of the substring which removes the numbers i hardcoded into the
                    // database for each team each week so the rest of the program still works and so the autocomplete in setupseason also still works.
                    Week01TeamsList.Add(String.IsNullOrEmpty(season1_5[i].ToString()) ? season1_5[i].ToString() : season1_5[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 02 -------------------------
            if (season1_5.Week02Team01 != "")
            {
                for (int i = 45; i <= 88; i++)
                {
                    Week02TeamsList.Add(String.IsNullOrEmpty(season1_5[i].ToString()) ? season1_5[i].ToString() : season1_5[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 03 -------------------------
            if (season1_5.Week03Team01 != "")
            {
                for (int i = 89; i <= 132; i++)
                {
                    Week03TeamsList.Add(String.IsNullOrEmpty(season1_5[i].ToString()) ? season1_5[i].ToString() : season1_5[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 04 -------------------------
            if (season1_5.Week04Team01 != "")
            {
                for (int i = 133; i <= 176; i++)
                {
                    Week04TeamsList.Add(String.IsNullOrEmpty(season1_5[i].ToString()) ? season1_5[i].ToString() : season1_5[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 05 -------------------------
            if (season1_5.Week05Team01 != "")
            {
                for (int i = 177; i <= 220; i++)
                {
                    Week05TeamsList.Add(String.IsNullOrEmpty(season1_5[i].ToString()) ? season1_5[i].ToString() : season1_5[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 06 -------------------------
            if (season6_10.Week06Team01 != "")
            {
                for (int i = 1; i <= 44; i++)
                {
                    Week06TeamsList.Add(String.IsNullOrEmpty(season6_10[i].ToString()) ? season6_10[i].ToString() : season6_10[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 07 -------------------------
            if (season6_10.Week07Team01 != "")
            {
                for (int i = 45; i <= 88; i++)
                {
                    Week07TeamsList.Add(String.IsNullOrEmpty(season6_10[i].ToString()) ? season6_10[i].ToString() : season6_10[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 08 -------------------------
            if (season6_10.Week08Team01 != "")
            {
                for (int i = 89; i <= 132; i++)
                {
                    Week08TeamsList.Add(String.IsNullOrEmpty(season6_10[i].ToString()) ? season6_10[i].ToString() : season6_10[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 09 -------------------------
            if (season6_10.Week09Team01 != "")
            {
                for (int i = 133; i <= 176; i++)
                {
                    Week09TeamsList.Add(String.IsNullOrEmpty(season6_10[i].ToString()) ? season6_10[i].ToString() : season6_10[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 10 -------------------------
            if (season6_10.Week10Team01 != "")
            {
                for (int i = 177; i <= 220; i++)
                {
                    Week10TeamsList.Add(String.IsNullOrEmpty(season6_10[i].ToString()) ? season6_10[i].ToString() : season6_10[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 11 -------------------------
            if (season11_17.Week11Team01 != "")
            {
                for (int i = 1; i <= 44; i++)
                {
                    Week11TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 12 -------------------------
            if (season11_17.Week12Team01 != "")
            {
                for (int i = 45; i <= 88; i++)
                {
                    Week12TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 13 -------------------------
            if (season11_17.Week13Team01 != "")
            {
                for (int i = 89; i <= 132; i++)
                {
                    Week13TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 14 -------------------------
            if (season11_17.Week14Team01 != "")
            {
                for (int i = 133; i <= 176; i++)
                {
                    Week14TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 15 -------------------------
            if (season11_17.Week15Team01 != "")
            {
                for (int i = 177; i <= 220; i++)
                {
                    Week15TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 16 -------------------------
            if (season11_17.Week16Team01 != "")
            {
                for (int i = 221; i <= 264; i++)
                {
                    Week16TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
            // ------------------- WEEK 17 -------------------------
            if (season11_17.Week17Team01 != "")
            {
                for (int i = 265; i <= 308; i++)
                {
                    Week17TeamsList.Add(String.IsNullOrEmpty(season11_17[i].ToString()) ? season11_17[i].ToString() : season11_17[i].ToString().Substring(2).Trim());
                }
            }
        }

        private void CreateNFLTeamList()
        {
            NFLTeamList.Add("PACKERS");
            NFLTeamList.Add("LIONS");
            NFLTeamList.Add("JETS");
            NFLTeamList.Add("GIANTS");
            NFLTeamList.Add("TEXANS");
            NFLTeamList.Add("BILLS");
            NFLTeamList.Add("CARDINALS");
            NFLTeamList.Add("RAMS");
            NFLTeamList.Add("FALCONS");
            NFLTeamList.Add("BUCCANEERS");
            NFLTeamList.Add("PANTHERS");
            NFLTeamList.Add("SAINTS");
            NFLTeamList.Add("SEAHAWKS");
            NFLTeamList.Add("VIKINGS");
            NFLTeamList.Add("RAVENS");
            NFLTeamList.Add("DOLPHINS");
            NFLTeamList.Add("BENGALS");
            NFLTeamList.Add("BROWNS");
            NFLTeamList.Add("JAGUARS");
            NFLTeamList.Add("TITANS");
            NFLTeamList.Add("49ERS");
            NFLTeamList.Add("BEARS");
            NFLTeamList.Add("BRONCOS");
            NFLTeamList.Add("CHARGERS");
            NFLTeamList.Add("CHIEFS");
            NFLTeamList.Add("RAIDERS");
            NFLTeamList.Add("EAGLES");
            NFLTeamList.Add("PATRIOTS");
            NFLTeamList.Add("COLTS");
            NFLTeamList.Add("STEELERS");
            NFLTeamList.Add("COWBOYS");
            NFLTeamList.Add("REDSKINS");
        }

        private void CreateCollegeTeamList()
        {
            CollegeTeamList.Add("ABILENE CHRISTIAN");
            CollegeTeamList.Add("AIR FORCE");
            CollegeTeamList.Add("AKRON");
            CollegeTeamList.Add("ALABAMA");
            CollegeTeamList.Add("ALABAMA A&M");
            CollegeTeamList.Add("ALABAMA STATE");
            CollegeTeamList.Add("ALBANY");
            CollegeTeamList.Add("ALCORN STATE");
            CollegeTeamList.Add("APPALACHIAN STATE");
            CollegeTeamList.Add("ARIZONA");
            CollegeTeamList.Add("ARIZONA STATE");
            CollegeTeamList.Add("ARKANSAS");
            CollegeTeamList.Add("ARKANSAS STATE");
            CollegeTeamList.Add("ARKANSAS-PINE BLUFF");
            CollegeTeamList.Add("ARMY");
            CollegeTeamList.Add("AUBURN");
            CollegeTeamList.Add("AUSTIN PEAY");
            CollegeTeamList.Add("BALL STATE");
            CollegeTeamList.Add("BAYLOR");
            CollegeTeamList.Add("BETHUNE-COOKMAN");
            CollegeTeamList.Add("BOISE STATE");
            CollegeTeamList.Add("BOSTON COLLEGE");
            CollegeTeamList.Add("BOWLING GREEN");
            CollegeTeamList.Add("BROWN");
            CollegeTeamList.Add("BRYANT");
            CollegeTeamList.Add("BUCKNELL");
            CollegeTeamList.Add("BUFFALO");
            CollegeTeamList.Add("BUTLER");
            CollegeTeamList.Add("BYU");
            CollegeTeamList.Add("CAL POLY");
            CollegeTeamList.Add("CALIFORNIA");
            CollegeTeamList.Add("CAMPBELL");
            CollegeTeamList.Add("CENTRAL ARKANSAS");
            CollegeTeamList.Add("CENTRAL CONNECTICUT");
            CollegeTeamList.Add("CENTRAL MICHIGAN");
            CollegeTeamList.Add("CHARLESTON SOUTHERN");
            CollegeTeamList.Add("CHARLOTTE");
            CollegeTeamList.Add("CHATTANOOGA");
            CollegeTeamList.Add("CINCINNATI");
            CollegeTeamList.Add("CLEMSON");
            CollegeTeamList.Add("COASTAL CAROLINA");
            CollegeTeamList.Add("COLGATE");
            CollegeTeamList.Add("COLORADO");
            CollegeTeamList.Add("COLORADO STATE");
            CollegeTeamList.Add("COLUMBIA");
            CollegeTeamList.Add("CONNECTICUT");
            CollegeTeamList.Add("CORNELL");
            CollegeTeamList.Add("DARTMOUTH");
            CollegeTeamList.Add("DAVIDSON");
            CollegeTeamList.Add("DAYTON");
            CollegeTeamList.Add("DELAWARE");
            CollegeTeamList.Add("DELAWARE STATE");
            CollegeTeamList.Add("DRAKE");
            CollegeTeamList.Add("DUKE");
            CollegeTeamList.Add("DUQUESNE");
            CollegeTeamList.Add("EAST CAROLINA");
            CollegeTeamList.Add("EAST TENNESSEE STATE");
            CollegeTeamList.Add("EASTERN ILLINOIS");
            CollegeTeamList.Add("EASTERN KENTUCKY");
            CollegeTeamList.Add("EASTERN MICHIGAN");
            CollegeTeamList.Add("EASTERN WASHINGTON");
            CollegeTeamList.Add("ELON");
            CollegeTeamList.Add("FLORIDA");
            CollegeTeamList.Add("FLORIDA A&M");
            CollegeTeamList.Add("FLORIDA ATLANTIC");
            CollegeTeamList.Add("FLORIDA INTL");
            CollegeTeamList.Add("FLORIDA STATE");
            CollegeTeamList.Add("FORDHAM");
            CollegeTeamList.Add("FRESNO STATE");
            CollegeTeamList.Add("FURMAN");
            CollegeTeamList.Add("GARDNER-WEBB");
            CollegeTeamList.Add("GEORGETOWN");
            CollegeTeamList.Add("GEORGIA");
            CollegeTeamList.Add("GEORGIA SOUTHERN");
            CollegeTeamList.Add("GEORGIA STATE");
            CollegeTeamList.Add("GEORGIA TECH");
            CollegeTeamList.Add("GRAMBLING");
            CollegeTeamList.Add("HAMPTON");
            CollegeTeamList.Add("HARVARD");
            CollegeTeamList.Add("HAWAI'I");
            CollegeTeamList.Add("HOLY CROSS");
            CollegeTeamList.Add("HOUSTON");
            CollegeTeamList.Add("HOUSTON BAPTIST");
            CollegeTeamList.Add("HOWARD");
            CollegeTeamList.Add("IDAHO");
            CollegeTeamList.Add("IDAHO STATE");
            CollegeTeamList.Add("ILLINOIS");
            CollegeTeamList.Add("ILLINOIS STATE");
            CollegeTeamList.Add("INCARNATE WORD");
            CollegeTeamList.Add("INDIANA");
            CollegeTeamList.Add("INDIANA STATE");
            CollegeTeamList.Add("IOWA");
            CollegeTeamList.Add("IOWA STATE");
            CollegeTeamList.Add("JACKSON STATE");
            CollegeTeamList.Add("JACKSONVILLE");
            CollegeTeamList.Add("JACKSONVILLE STATE");
            CollegeTeamList.Add("JAMES MADISON");
            CollegeTeamList.Add("KANSAS");
            CollegeTeamList.Add("KANSAS STATE");
            CollegeTeamList.Add("KENNESAW STATE");
            CollegeTeamList.Add("KENT STATE");
            CollegeTeamList.Add("KENTUCKY");
            CollegeTeamList.Add("LAFAYETTE");
            CollegeTeamList.Add("LAMAR");
            CollegeTeamList.Add("LEHIGH");
            CollegeTeamList.Add("LIBERTY");
            CollegeTeamList.Add("LOUISIANA MONROE");
            CollegeTeamList.Add("LOUISIANA TECH");
            CollegeTeamList.Add("LOUISVILLE");
            CollegeTeamList.Add("LSU");
            CollegeTeamList.Add("MAINE");
            CollegeTeamList.Add("MARIST");
            CollegeTeamList.Add("MARSHALL");
            CollegeTeamList.Add("MARYLAND");
            CollegeTeamList.Add("MASSACHUSETTS");
            CollegeTeamList.Add("MCNEESE");
            CollegeTeamList.Add("MEMPHIS");
            CollegeTeamList.Add("MERCER");
            CollegeTeamList.Add("MIAMI");
            CollegeTeamList.Add("MIAMI (OH)");
            CollegeTeamList.Add("MICHIGAN");
            CollegeTeamList.Add("MICHIGAN STATE");
            CollegeTeamList.Add("MIDDLE TENNESSEE");
            CollegeTeamList.Add("MINNESOTA");
            CollegeTeamList.Add("MISSISSIPPI STATE");
            CollegeTeamList.Add("MISSISSIPPI VALLEY STATE");
            CollegeTeamList.Add("MISSOURI STATE");
            CollegeTeamList.Add("MONMOUTH");
            CollegeTeamList.Add("MONTANA");
            CollegeTeamList.Add("MONTANA STATE");
            CollegeTeamList.Add("MOREHEAD STATE");
            CollegeTeamList.Add("MORGAN STATE");
            CollegeTeamList.Add("MURRAY STATE");
            CollegeTeamList.Add("NAVY");
            CollegeTeamList.Add("NC STATE");
            CollegeTeamList.Add("NEBRASKA");
            CollegeTeamList.Add("NEVADA");
            CollegeTeamList.Add("NEW HAMPSHIRE");
            CollegeTeamList.Add("NEW MEXICO");
            CollegeTeamList.Add("NEW MEXICO STATE");
            CollegeTeamList.Add("NICHOLLS");
            CollegeTeamList.Add("NORFOLK STATE");
            CollegeTeamList.Add("NORTH CAROLINA");
            CollegeTeamList.Add("NORTH CAROLINA A&T");
            CollegeTeamList.Add("NORTH CAROLINA CENTRAL");
            CollegeTeamList.Add("NORTH DAKOTA");
            CollegeTeamList.Add("NORTH DAKOTA STATE");
            CollegeTeamList.Add("NORTH TEXAS");
            CollegeTeamList.Add("NORTHERN ARIZONA");
            CollegeTeamList.Add("NORTHERN COLORADO");
            CollegeTeamList.Add("NORTHERN ILLINOIS");
            CollegeTeamList.Add("NORTHERN IOWA");
            CollegeTeamList.Add("NORTHWESTERN");
            CollegeTeamList.Add("NORTHWESTERN STATE");
            CollegeTeamList.Add("NOTRE DAME");
            CollegeTeamList.Add("OHIO");
            CollegeTeamList.Add("OHIO STATE");
            CollegeTeamList.Add("OKLAHOMA");
            CollegeTeamList.Add("OKLAHOMA STATE");
            CollegeTeamList.Add("OLD DOMINION");
            CollegeTeamList.Add("OLE MISS");
            CollegeTeamList.Add("OREGON");
            CollegeTeamList.Add("OREGON STATE");
            CollegeTeamList.Add("PENN STATE");
            CollegeTeamList.Add("PENNSYLVANIA");
            CollegeTeamList.Add("PITTSBURGH");
            CollegeTeamList.Add("PORTLAND STATE");
            CollegeTeamList.Add("PRAIRIE VIEW");
            CollegeTeamList.Add("PRESBYTERIAN COLLEGE");
            CollegeTeamList.Add("PRINCETON");
            CollegeTeamList.Add("PURDUE");
            CollegeTeamList.Add("RHODE ISLAND");
            CollegeTeamList.Add("RICE");
            CollegeTeamList.Add("RICHMOND");
            CollegeTeamList.Add("ROBERT MORRIS");
            CollegeTeamList.Add("RUTGERS");
            CollegeTeamList.Add("SACRAMENTO STATE");
            CollegeTeamList.Add("SACRED HEART");
            CollegeTeamList.Add("SAM HOUSTON STATE");
            CollegeTeamList.Add("SAMFORD");
            CollegeTeamList.Add("SAN DIEGO");
            CollegeTeamList.Add("SAN DIEGO STATE");
            CollegeTeamList.Add("SAN JOSÉ STATE");
            CollegeTeamList.Add("SAVANNAH STATE");
            CollegeTeamList.Add("SMU");
            CollegeTeamList.Add("SOUTH ALABAMA");
            CollegeTeamList.Add("SOUTH CAROLINA");
            CollegeTeamList.Add("SOUTH CAROLINA STATE");
            CollegeTeamList.Add("SOUTH DAKOTA");
            CollegeTeamList.Add("SOUTH DAKOTA STATE");
            CollegeTeamList.Add("SOUTH FLORIDA");
            CollegeTeamList.Add("SOUTHEAST MISSOURI STATE");
            CollegeTeamList.Add("SOUTHEASTERN LOUISIANA");
            CollegeTeamList.Add("SOUTHERN ILLINOIS");
            CollegeTeamList.Add("SOUTHERN MISSISSIPPI");
            CollegeTeamList.Add("SOUTHERN UTAH");
            CollegeTeamList.Add("SOUTHLAND");
            CollegeTeamList.Add("ST FRANCIS (PA)");
            CollegeTeamList.Add("STANFORD");
            CollegeTeamList.Add("STEPHEN F. AUSTIN");
            CollegeTeamList.Add("STETSON");
            CollegeTeamList.Add("STONY BROOK");
            CollegeTeamList.Add("SYRACUSE");
            CollegeTeamList.Add("TCU");
            CollegeTeamList.Add("TEMPLE");
            CollegeTeamList.Add("TENNESSEE");
            CollegeTeamList.Add("TENNESSEE STATE");
            CollegeTeamList.Add("TENNESSEE TECH");
            CollegeTeamList.Add("TEXAS");
            CollegeTeamList.Add("TEXAS A&M");
            CollegeTeamList.Add("TEXAS SOUTHERN");
            CollegeTeamList.Add("TEXAS STATE");
            CollegeTeamList.Add("TEXAS TECH");
            CollegeTeamList.Add("THE CITADEL");
            CollegeTeamList.Add("TOLEDO");
            CollegeTeamList.Add("TOWSON");
            CollegeTeamList.Add("TROY");
            CollegeTeamList.Add("TULANE");
            CollegeTeamList.Add("TULSA");
            CollegeTeamList.Add("UAB");
            CollegeTeamList.Add("UC DAVIS");
            CollegeTeamList.Add("UCF");
            CollegeTeamList.Add("UCLA");
            CollegeTeamList.Add("UL LAFAYETTE");
            CollegeTeamList.Add("UNLV");
            CollegeTeamList.Add("USC");
            CollegeTeamList.Add("UT MARTIN");
            CollegeTeamList.Add("UT SAN ANTONIO");
            CollegeTeamList.Add("UTAH");
            CollegeTeamList.Add("UTAH STATE");
            CollegeTeamList.Add("UTEP");
            CollegeTeamList.Add("VALPARAISO");
            CollegeTeamList.Add("VANDERBILT");
            CollegeTeamList.Add("VILLANOVA");
            CollegeTeamList.Add("VIRGINIA");
            CollegeTeamList.Add("VIRGINIA TECH");
            CollegeTeamList.Add("VMI");
            CollegeTeamList.Add("WAGNER");
            CollegeTeamList.Add("WAKE FOREST");
            CollegeTeamList.Add("WASHINGTON");
            CollegeTeamList.Add("WASHINGTON STATE");
            CollegeTeamList.Add("WEBER STATE");
            CollegeTeamList.Add("WEST VIRGINIA");
            CollegeTeamList.Add("WESTERN CAROLINA");
            CollegeTeamList.Add("WESTERN ILLINOIS");
            CollegeTeamList.Add("WESTERN KENTUCKY");
            CollegeTeamList.Add("WESTERN MICHIGAN");
            CollegeTeamList.Add("WILLIAM & MARY");
            CollegeTeamList.Add("WISCONSIN");
            CollegeTeamList.Add("WOFFORD");
            CollegeTeamList.Add("WYOMING");
            CollegeTeamList.Add("YALE");
            CollegeTeamList.Add("YOUNGSTOWN STATE");
        }

        private SeasonsDBDataSet.Seasons1_5Row FindSeason1_5()
        {
            foreach (SeasonsDBDataSet.Seasons1_5Row season1_5_5 in seasonsDBDataSet.Seasons1_5)
            {
                if (season1_5_5.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    return season1_5_5;
                }
            }
            return null;
        }

        private SeasonsDBDataSet.Seasons6_10Row FindSeason6_10()
        {
            foreach (SeasonsDBDataSet.Seasons6_10Row selectedSeason6_10 in seasonsDBDataSet.Seasons6_10)
            {
                if (selectedSeason6_10.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    return selectedSeason6_10;
                }
            }
            return null;
        }

        private SeasonsDBDataSet.Seasons11_17Row FindSeason11_17()
        {
            foreach (SeasonsDBDataSet.Seasons11_17Row season1_51_17 in seasonsDBDataSet.Seasons11_17)
            {
                if (season1_51_17.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    return season1_51_17;
                }
            }
            return null;
        }

        private void OldListCode()
        {
            /*
             *             // week 1 teams added to list
            Week01TeamsList.Add(season1_5.Week01Team01.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team02.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team03.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team04.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team05.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team06.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team07.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team08.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team09.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team10.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team11.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team12.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team13.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team14.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team15.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team16.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team17.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team18.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team19.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team20.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team21.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team22.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team23.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team24.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team25.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team26.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team27.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team28.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team29.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team30.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team31.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team32.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team33.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team34.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team35.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team36.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team37.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team38.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team39.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team40.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team41.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team42.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team43.Substring(2).Trim());
            Week01TeamsList.Add(season1_5.Week01Team44.Substring(2).Trim());
	
            // week 2 teams added to list	
            Week02TeamsList.Add(season1_5.Week02Team01.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team02.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team03.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team04.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team05.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team06.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team07.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team08.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team09.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team10.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team11.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team12.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team13.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team14.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team15.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team16.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team17.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team18.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team19.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team20.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team21.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team22.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team23.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team24.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team25.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team26.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team27.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team28.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team29.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team30.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team31.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team32.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team33.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team34.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team35.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team36.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team37.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team38.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team39.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team40.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team41.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team42.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team43.Substring(2).Trim());
            Week02TeamsList.Add(season1_5.Week02Team44.Substring(2).Trim());
	
	
            // week 03 teams added to list	
            Week03TeamsList.Add(season1_5.Week03Team01.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team02.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team03.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team04.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team05.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team06.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team07.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team08.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team09.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team10.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team11.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team12.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team13.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team14.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team15.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team16.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team17.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team18.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team19.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team20.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team21.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team22.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team23.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team24.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team25.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team26.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team27.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team28.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team29.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team30.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team31.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team32.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team33.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team34.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team35.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team36.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team37.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team38.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team39.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team40.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team41.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team42.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team43.Substring(2).Trim());
            Week03TeamsList.Add(season1_5.Week03Team44.Substring(2).Trim());
	
            // week 04 teams added to list	
            Week04TeamsList.Add(season1_5.Week04Team01.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team02.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team03.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team04.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team05.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team06.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team07.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team08.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team09.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team10.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team11.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team12.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team13.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team14.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team15.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team16.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team17.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team18.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team19.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team20.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team21.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team22.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team23.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team24.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team25.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team26.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team27.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team28.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team29.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team30.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team31.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team32.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team33.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team34.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team35.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team36.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team37.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team38.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team39.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team40.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team41.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team42.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team43.Substring(2).Trim());
            Week04TeamsList.Add(season1_5.Week04Team44.Substring(2).Trim());
	
            // week 05 teams added to list	
            Week05TeamsList.Add(season1_5.Week05Team01.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team02.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team03.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team04.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team05.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team06.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team07.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team08.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team09.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team10.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team11.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team12.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team13.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team14.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team15.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team16.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team17.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team18.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team19.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team20.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team21.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team22.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team23.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team24.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team25.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team26.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team27.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team28.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team29.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team30.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team31.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team32.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team33.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team34.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team35.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team36.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team37.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team38.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team39.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team40.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team41.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team42.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team43.Substring(2).Trim());
            Week05TeamsList.Add(season1_5.Week05Team44.Substring(2).Trim());
	
            // week 06 teams added to list	
            Week06TeamsList.Add(season6_10.Week06Team01.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team02.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team03.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team04.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team05.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team06.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team07.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team08.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team09.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team10.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team11.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team12.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team13.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team14.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team15.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team16.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team17.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team18.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team19.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team20.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team21.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team22.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team23.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team24.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team25.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team26.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team27.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team28.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team29.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team30.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team31.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team32.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team33.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team34.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team35.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team36.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team37.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team38.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team39.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team40.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team41.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team42.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team43.Substring(2).Trim());
            Week06TeamsList.Add(season6_10.Week06Team44.Substring(2).Trim());
	
            // week 07 teams added to list	
            Week07TeamsList.Add(season6_10.Week07Team01.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team02.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team03.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team04.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team05.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team06.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team07.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team08.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team09.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team10.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team11.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team12.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team13.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team14.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team15.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team16.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team17.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team18.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team19.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team20.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team21.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team22.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team23.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team24.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team25.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team26.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team27.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team28.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team29.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team30.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team31.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team32.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team33.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team34.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team35.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team36.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team37.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team38.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team39.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team40.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team41.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team42.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team43.Substring(2).Trim());
            Week07TeamsList.Add(season6_10.Week07Team44.Substring(2).Trim());
	
            // week 08 teams added to list	
            Week08TeamsList.Add(season6_10.Week08Team01.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team02.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team03.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team04.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team05.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team06.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team07.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team08.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team09.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team10.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team11.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team12.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team13.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team14.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team15.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team16.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team17.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team18.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team19.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team20.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team21.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team22.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team23.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team24.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team25.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team26.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team27.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team28.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team29.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team30.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team31.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team32.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team33.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team34.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team35.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team36.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team37.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team38.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team39.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team40.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team41.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team42.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team43.Substring(2).Trim());
            Week08TeamsList.Add(season6_10.Week08Team44.Substring(2).Trim());
	
            // week 09 teams added to list	
            Week09TeamsList.Add(season6_10.Week09Team01.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team02.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team03.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team04.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team05.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team06.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team07.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team08.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team09.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team10.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team11.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team12.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team13.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team14.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team15.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team16.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team17.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team18.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team19.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team20.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team21.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team22.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team23.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team24.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team25.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team26.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team27.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team28.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team29.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team30.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team31.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team32.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team33.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team34.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team35.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team36.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team37.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team38.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team39.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team40.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team41.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team42.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team43.Substring(2).Trim());
            Week09TeamsList.Add(season6_10.Week09Team44.Substring(2).Trim());
	
            // week 10 teams added to list	
            Week10TeamsList.Add(season6_10.Week10Team01.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team02.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team03.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team04.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team05.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team06.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team07.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team08.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team09.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team10.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team11.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team12.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team13.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team14.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team15.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team16.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team17.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team18.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team19.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team20.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team21.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team22.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team23.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team24.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team25.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team26.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team27.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team28.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team29.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team30.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team31.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team32.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team33.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team34.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team35.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team36.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team37.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team38.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team39.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team40.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team41.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team42.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team43.Substring(2).Trim());
            Week10TeamsList.Add(season6_10.Week10Team44.Substring(2).Trim());
	
            // week 11 teams added to list	
            Week11TeamsList.Add(season11_17.Week11Team01.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team02.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team03.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team04.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team05.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team06.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team07.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team08.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team09.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team10.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team11.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team12.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team13.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team14.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team15.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team16.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team17.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team18.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team19.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team20.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team21.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team22.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team23.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team24.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team25.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team26.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team27.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team28.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team29.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team30.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team31.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team32.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team33.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team34.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team35.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team36.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team37.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team38.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team39.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team40.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team41.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team42.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team43.Substring(2).Trim());
            Week11TeamsList.Add(season11_17.Week11Team44.Substring(2).Trim());
	
            // week 12 teams added to list	
            Week12TeamsList.Add(season11_17.Week12Team01.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team02.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team03.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team04.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team05.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team06.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team07.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team08.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team09.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team10.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team11.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team12.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team13.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team14.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team15.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team16.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team17.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team18.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team19.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team20.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team21.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team22.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team23.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team24.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team25.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team26.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team27.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team28.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team29.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team30.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team31.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team32.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team33.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team34.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team35.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team36.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team37.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team38.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team39.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team40.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team41.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team42.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team43.Substring(2).Trim());
            Week12TeamsList.Add(season11_17.Week12Team44.Substring(2).Trim());
	
            // week 13 teams added to list	
            Week13TeamsList.Add(season11_17.Week13Team01.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team02.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team03.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team04.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team05.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team06.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team07.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team08.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team09.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team10.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team11.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team12.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team13.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team14.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team15.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team16.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team17.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team18.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team19.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team20.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team21.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team22.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team23.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team24.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team25.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team26.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team27.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team28.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team29.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team30.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team31.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team32.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team33.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team34.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team35.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team36.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team37.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team38.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team39.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team40.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team41.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team42.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team43.Substring(2).Trim());
            Week13TeamsList.Add(season11_17.Week13Team44.Substring(2).Trim());
	
            // week 14 teams added to list	
            Week14TeamsList.Add(season11_17.Week14Team01.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team02.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team03.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team04.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team05.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team06.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team07.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team08.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team09.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team10.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team11.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team12.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team13.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team14.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team15.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team16.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team17.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team18.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team19.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team20.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team21.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team22.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team23.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team24.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team25.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team26.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team27.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team28.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team29.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team30.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team31.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team32.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team33.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team34.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team35.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team36.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team37.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team38.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team39.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team40.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team41.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team42.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team43.Substring(2).Trim());
            Week14TeamsList.Add(season11_17.Week14Team44.Substring(2).Trim());
	
            // week 15 teams added to list	
            Week15TeamsList.Add(season11_17.Week15Team01.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team02.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team03.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team04.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team05.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team06.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team07.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team08.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team09.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team10.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team11.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team12.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team13.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team14.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team15.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team16.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team17.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team18.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team19.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team20.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team21.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team22.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team23.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team24.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team25.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team26.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team27.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team28.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team29.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team30.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team31.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team32.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team33.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team34.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team35.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team36.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team37.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team38.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team39.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team40.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team41.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team42.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team43.Substring(2).Trim());
            Week15TeamsList.Add(season11_17.Week15Team44.Substring(2).Trim());
	
            // week 16 teams added to list	
            Week16TeamsList.Add(season11_17.Week16Team01.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team02.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team03.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team04.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team05.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team06.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team07.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team08.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team09.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team10.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team11.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team12.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team13.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team14.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team15.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team16.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team17.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team18.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team19.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team20.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team21.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team22.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team23.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team24.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team25.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team26.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team27.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team28.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team29.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team30.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team31.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team32.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team33.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team34.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team35.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team36.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team37.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team38.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team39.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team40.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team41.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team42.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team43.Substring(2).Trim());
            Week16TeamsList.Add(season11_17.Week16Team44.Substring(2).Trim());
	
            // week 17 teams added to list	
            Week17TeamsList.Add(season11_17.Week17Team01.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team02.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team03.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team04.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team05.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team06.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team07.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team08.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team09.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team10.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team11.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team12.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team13.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team14.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team15.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team16.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team17.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team18.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team19.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team20.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team21.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team22.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team23.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team24.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team25.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team26.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team27.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team28.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team29.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team30.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team31.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team32.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team33.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team34.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team35.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team36.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team37.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team38.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team39.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team40.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team41.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team42.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team43.Substring(2).Trim());
            Week17TeamsList.Add(season11_17.Week17Team44.Substring(2).Trim());
            */
        }
    }
}
