using System;
using System.Drawing;
using System.Windows.Forms;


namespace Saatphere_WIN.Tools
{
    public partial class FrmCalender : Form
    {
        public enum DayofWeekNumber
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday= 4,
            Friday = 5,
            Saturday =6,
            Sunday = 7
        }
        
        string[] strDays = new string[43];
        string[] strMonths = new string[43];
        string[] strYears = new string[43];
        string[] strRecordsCount = new string[43];
        DateTime dateInOperation = new DateTime();
        
        //Date Font Style
        string dateFontName = "Arial";
        int dateFontSize = 14;
        FontStyle fontStyle = FontStyle.Regular;
        Brush brush = Brushes.Green;

        int currentMonthLastDay = 0;

        public FrmCalender()
        {
            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();

            

            InitializeInformation();
            
            Cursor.Current = Cursors.Arrow;
        }

        private void InitializeInformation()
        {
            if (dateInOperation.Year == 1)
            {
                dateInOperation = DateTime.Now;
            }                       
            
            FillCalendar(); //Prepares the month day and year in the array and fills that in the paint event
            SetRecordsCount(); //Sets the record count from database
            DelegateEvents(); //Paint event delegates
            this.Invalidate();
            this.Update();
            this.Refresh();
        }

        private void DelegateEvents()
        {
            //lblMonthDetails.Paint += PaintInformation;
            WeeekOneMonday.Paint += PaintInformation;
            WeeekOneTuesday.Paint += PaintInformation;
            WeeekOneWednesday.Paint += PaintInformation;
            WeeekOneThursday.Paint += PaintInformation;
            WeeekOneFriday.Paint += PaintInformation;
            WeeekOneSaturday.Paint += PaintInformation;
            WeeekOneSunday.Paint += PaintInformation;

            WeeekTwoMonday.Paint += PaintInformation;
            WeeekTwoTuesday.Paint += PaintInformation;
            WeeekTwoWednesday.Paint += PaintInformation;
            WeeekTwoThursday.Paint += PaintInformation;
            WeeekTwoFriday.Paint += PaintInformation;
            WeeekTwoSaturday.Paint += PaintInformation;
            WeeekTwoSunday.Paint += PaintInformation;

            WeeekThreeMonday.Paint += PaintInformation;
            WeeekThreeTuesday.Paint += PaintInformation;
            WeeekThreeWednesday.Paint += PaintInformation;
            WeeekThreeThursday.Paint += PaintInformation;
            WeeekThreeFriday.Paint += PaintInformation;
            WeeekThreeSaturday.Paint += PaintInformation;
            WeeekThreeSunday.Paint += PaintInformation;

            WeeekFourMonday.Paint += PaintInformation;
            WeeekFourTuesday.Paint += PaintInformation;
            WeeekFourWednesday.Paint += PaintInformation;
            WeeekFourThursday.Paint += PaintInformation;
            WeeekFourFriday.Paint += PaintInformation;
            WeeekFourSaturday.Paint += PaintInformation;
            WeeekFourSunday.Paint += PaintInformation;

            WeeekFiveMonday.Paint += PaintInformation;
            WeeekFiveTuesday.Paint += PaintInformation;
            WeeekFiveWednesday.Paint += PaintInformation;
            WeeekFiveThursday.Paint += PaintInformation;
            WeeekFiveFriday.Paint += PaintInformation;
            WeeekFiveSaturday.Paint += PaintInformation;
            WeeekFiveSunday.Paint += PaintInformation;

            WeeekSixMonday.Paint += PaintInformation;
            WeeekSixTuesday.Paint += PaintInformation;
            WeeekSixWednesday.Paint += PaintInformation;
            WeeekSixThursday.Paint += PaintInformation;
            WeeekSixFriday.Paint += PaintInformation;
            WeeekSixSaturday.Paint += PaintInformation;
            WeeekSixSunday.Paint += PaintInformation;


            WeeekOneMonday.Click += Tile_Click;
            WeeekOneTuesday.Click += Tile_Click;
            WeeekOneWednesday.Click += Tile_Click;
            WeeekOneThursday.Click += Tile_Click;
            WeeekOneFriday.Click += Tile_Click;
            WeeekOneSaturday.Click += Tile_Click;
            WeeekOneSunday.Click += Tile_Click;

            WeeekTwoMonday.Click += Tile_Click;
            WeeekTwoTuesday.Click += Tile_Click;
            WeeekTwoWednesday.Click += Tile_Click;
            WeeekTwoThursday.Click += Tile_Click;
            WeeekTwoFriday.Click += Tile_Click;
            WeeekTwoSaturday.Click += Tile_Click;
            WeeekTwoSunday.Click += Tile_Click;

            WeeekThreeMonday.Click += Tile_Click;
            WeeekThreeTuesday.Click += Tile_Click;
            WeeekThreeWednesday.Click += Tile_Click;
            WeeekThreeThursday.Click += Tile_Click;
            WeeekThreeFriday.Click += Tile_Click;
            WeeekThreeSaturday.Click += Tile_Click;
            WeeekThreeSunday.Click += Tile_Click;

            WeeekFourMonday.Click += Tile_Click;
            WeeekFourTuesday.Click += Tile_Click;
            WeeekFourWednesday.Click += Tile_Click;
            WeeekFourThursday.Click += Tile_Click;
            WeeekFourFriday.Click += Tile_Click;
            WeeekFourSaturday.Click += Tile_Click;
            WeeekFourSunday.Click += Tile_Click;

            WeeekFiveMonday.Click += Tile_Click;
            WeeekFiveTuesday.Click += Tile_Click;
            WeeekFiveWednesday.Click += Tile_Click;
            WeeekFiveThursday.Click += Tile_Click;
            WeeekFiveFriday.Click += Tile_Click;
            WeeekFiveSaturday.Click += Tile_Click;
            WeeekFiveSunday.Click += Tile_Click;

            WeeekSixMonday.Click += Tile_Click;
            WeeekSixTuesday.Click += Tile_Click;
            WeeekSixWednesday.Click += Tile_Click;
            WeeekSixThursday.Click += Tile_Click;
            WeeekSixFriday.Click += Tile_Click;
            WeeekSixSaturday.Click += Tile_Click;
            WeeekSixSunday.Click += Tile_Click;
        }

        private void SetRecordsCount()
        {
            for(int i=0; i<= strRecordsCount.GetUpperBound(0); i++)
            {
                //Sometimes due to wrong datetime format in the profiles, it generates exceptions, to avoid those exceptions
                //we bypass it by using try and catch, the datetime can be corrected explicitly
                try
                {
                    strRecordsCount[i] = new SaatphereWIN.DAL.Membership.ClsSelect().GetQueuebyDateCount(dtTemp, Convert.ToInt32(SaatphereWIN.DAL.Global.FrRowId)).ToString();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCalender_Load(object sender, EventArgs e)
        {
            lblMonthDetails.Text = DateTime.Now.ToString("MMMM yyyy");
        }

        private void DisposeControls()
        {
            WeeekOneMonday.Paint -= PaintInformation;
            WeeekOneTuesday.Paint -= PaintInformation;
            WeeekOneWednesday.Paint -= PaintInformation;
            WeeekOneThursday.Paint -= PaintInformation;
            WeeekOneFriday.Paint -= PaintInformation;
            WeeekOneSaturday.Paint -= PaintInformation;
            WeeekOneSunday.Paint -= PaintInformation;

            WeeekTwoMonday.Paint -= PaintInformation;
            WeeekTwoTuesday.Paint -= PaintInformation;
            WeeekTwoWednesday.Paint -= PaintInformation;
            WeeekTwoThursday.Paint -= PaintInformation;
            WeeekTwoFriday.Paint -= PaintInformation;
            WeeekTwoSaturday.Paint -= PaintInformation;
            WeeekTwoSunday.Paint -= PaintInformation;

            WeeekThreeMonday.Paint -= PaintInformation;
            WeeekThreeTuesday.Paint -= PaintInformation;
            WeeekThreeWednesday.Paint -= PaintInformation;
            WeeekThreeThursday.Paint -= PaintInformation;
            WeeekThreeFriday.Paint -= PaintInformation;
            WeeekThreeSaturday.Paint -= PaintInformation;
            WeeekThreeSunday.Paint -= PaintInformation;

            WeeekFourMonday.Paint -= PaintInformation;
            WeeekFourTuesday.Paint -= PaintInformation;
            WeeekFourWednesday.Paint -= PaintInformation;
            WeeekFourThursday.Paint -= PaintInformation;
            WeeekFourFriday.Paint -= PaintInformation;
            WeeekFourSaturday.Paint -= PaintInformation;
            WeeekFourSunday.Paint -= PaintInformation;

            WeeekFiveMonday.Paint -= PaintInformation;
            WeeekFiveTuesday.Paint -= PaintInformation;
            WeeekFiveWednesday.Paint -= PaintInformation;
            WeeekFiveThursday.Paint -= PaintInformation;
            WeeekFiveFriday.Paint -= PaintInformation;
            WeeekFiveSaturday.Paint -= PaintInformation;
            WeeekFiveSunday.Paint -= PaintInformation;

            WeeekSixMonday.Paint -= PaintInformation;
            WeeekSixTuesday.Paint -= PaintInformation;
            WeeekSixWednesday.Paint -= PaintInformation;
            WeeekSixThursday.Paint -= PaintInformation;
            WeeekSixFriday.Paint -= PaintInformation;
            WeeekSixSaturday.Paint -= PaintInformation;
            WeeekSixSunday.Paint -= PaintInformation;


            WeeekOneMonday.Click -= Tile_Click;
            WeeekOneTuesday.Click -= Tile_Click;
            WeeekOneWednesday.Click -= Tile_Click;
            WeeekOneThursday.Click -= Tile_Click;
            WeeekOneFriday.Click -= Tile_Click;
            WeeekOneSaturday.Click -= Tile_Click;
            WeeekOneSunday.Click -= Tile_Click;

            WeeekTwoMonday.Click -= Tile_Click;
            WeeekTwoTuesday.Click -= Tile_Click;
            WeeekTwoWednesday.Click -= Tile_Click;
            WeeekTwoThursday.Click -= Tile_Click;
            WeeekTwoFriday.Click -= Tile_Click;
            WeeekTwoSaturday.Click -= Tile_Click;
            WeeekTwoSunday.Click -= Tile_Click;

            WeeekThreeMonday.Click -= Tile_Click;
            WeeekThreeTuesday.Click -= Tile_Click;
            WeeekThreeWednesday.Click -= Tile_Click;
            WeeekThreeThursday.Click -= Tile_Click;
            WeeekThreeFriday.Click -= Tile_Click;
            WeeekThreeSaturday.Click -= Tile_Click;
            WeeekThreeSunday.Click -= Tile_Click;

            WeeekFourMonday.Click -= Tile_Click;
            WeeekFourTuesday.Click -= Tile_Click;
            WeeekFourWednesday.Click -= Tile_Click;
            WeeekFourThursday.Click -= Tile_Click;
            WeeekFourFriday.Click -= Tile_Click;
            WeeekFourSaturday.Click -= Tile_Click;
            WeeekFourSunday.Click -= Tile_Click;

            WeeekFiveMonday.Click -= Tile_Click;
            WeeekFiveTuesday.Click -= Tile_Click;
            WeeekFiveWednesday.Click -= Tile_Click;
            WeeekFiveThursday.Click -= Tile_Click;
            WeeekFiveFriday.Click -= Tile_Click;
            WeeekFiveSaturday.Click -= Tile_Click;
            WeeekFiveSunday.Click -= Tile_Click;

            WeeekSixMonday.Click -= Tile_Click;
            WeeekSixTuesday.Click -= Tile_Click;
            WeeekSixWednesday.Click -= Tile_Click;
            WeeekSixThursday.Click -= Tile_Click;
            WeeekSixFriday.Click -= Tile_Click;
            WeeekSixSaturday.Click -= Tile_Click;
            WeeekSixSunday.Click -= Tile_Click;

            //this.Update();
            //this.Refresh();
        }

        private void FillCalendar()
        {
            DateTime dt = new DateTime(dateInOperation.Year, dateInOperation.Month, 1);
            int lastMonthStartDayforFirstWeekinCalendar = dt.AddDays(-(GetDayofWeekfromDate(dateInOperation.Year, dateInOperation.Month, 1) - 1)).Day;
            int lastMonthLastDay = dt.AddDays(-1).Day;
            currentMonthLastDay = System.DateTime.DaysInMonth(dateInOperation.Year, dateInOperation.Month);
            int dayCounter = 0;
            int monthCounter = 0;
            int weekCounter = 1;
            int yearCounter = 1;

            dayCounter = lastMonthStartDayforFirstWeekinCalendar;

            for (int i = 0; i <= 42; i++)
            {               
                strDays[i] = dayCounter.ToString();

                if (weekCounter == 1) //if dayCounter > 1 then it means the day is of the last month. will check only in week 1 
                {
                    if (dayCounter >= 7) //7 = max day of the current week to match the highese value of last month days
                    {
                        monthCounter = dateInOperation.Date.AddMonths(-1).Month;
                    }
                    else
                    {
                        monthCounter = dateInOperation.Date.Month;
                    }
                }

                if (weekCounter == 5 || weekCounter == 6)
                {
                    if (dayCounter > currentMonthLastDay || dayCounter <= 7)
                    {
                        monthCounter = dateInOperation.Date.AddMonths(1).Month;
                    }
                    else
                    {
                        monthCounter = dateInOperation.Date.Month;
                    }
                }

                strMonths[i] = monthCounter.ToString();


                if (weekCounter == 1)
                {
                    if (dayCounter >= 7) //7 = max day of the current week to match the highese value of last month days
                    {
                        monthCounter = dateInOperation.Date.AddMonths(-1).Month;

                        if (monthCounter == 12) //If after subtraction from current month the month comes 12 then they year should be subtracted by 1
                        {
                            yearCounter = dateInOperation.Date.AddYears(-1).Year;
                        }
                    }
                    else
                    {
                        monthCounter = dateInOperation.Date.Month;
                        yearCounter = dateInOperation.Date.Year;
                    }
                }

                if(yearCounter == 1)
                    yearCounter = DateTime.Now.Year;

                strYears[i] = yearCounter.ToString();                

                if (dayCounter == lastMonthLastDay || dayCounter == currentMonthLastDay)
                {
                    dayCounter = 0;
                }

                if (dayCounter == 6 || dayCounter == 13 || dayCounter == 20 || dayCounter == 27 || dayCounter == 34)
                    weekCounter++;


                dayCounter++;
            }
        }

        private void SetDays()
        {
            string[] strDays = new string[29];
        }

        private int DayofWeekinNumber(DayofWeekNumber weekDay)
        {
            return Convert.ToInt32(weekDay);
        }

        private int GetDayofWeekfromDate(int Year, int Month, int Day)
        {
            DateTime dateValue = new DateTime(Year, Month, Day);
            return (int)dateValue.DayOfWeek;  
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            #region Week One
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneMonday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[0]), Convert.ToInt32(strMonths[0]), Convert.ToInt32(strDays[0]));
                new FrmCalendarActivities(dt).ShowDialog();   
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneTuesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[1]), Convert.ToInt32(strMonths[1]), Convert.ToInt32(strDays[1]));
                new FrmCalendarActivities(dt).ShowDialog();    
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneWednesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[2]), Convert.ToInt32(strMonths[2]), Convert.ToInt32(strDays[2]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneThursday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[3]), Convert.ToInt32(strMonths[3]), Convert.ToInt32(strDays[3]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneFriday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[4]), Convert.ToInt32(strMonths[4]), Convert.ToInt32(strDays[4]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneSaturday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[5]), Convert.ToInt32(strMonths[5]), Convert.ToInt32(strDays[5]));
                new FrmCalendarActivities(dt).ShowDialog();    
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneSunday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[6]), Convert.ToInt32(strMonths[6]), Convert.ToInt32(strDays[6]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }
            #endregion

            #region Week Two
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoMonday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[7]), Convert.ToInt32(strMonths[7]), Convert.ToInt32(strDays[7]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoTuesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[8]), Convert.ToInt32(strMonths[8]), Convert.ToInt32(strDays[8]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoWednesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[9]), Convert.ToInt32(strMonths[9]), Convert.ToInt32(strDays[9]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoThursday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[10]), Convert.ToInt32(strMonths[10]), Convert.ToInt32(strDays[10]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoFriday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[11]), Convert.ToInt32(strMonths[11]), Convert.ToInt32(strDays[11]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoSaturday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[12]), Convert.ToInt32(strMonths[12]), Convert.ToInt32(strDays[12]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoSunday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[13]), Convert.ToInt32(strMonths[13]), Convert.ToInt32(strDays[13]));
                new FrmCalendarActivities(dt).ShowDialog();   
            }
            #endregion

            #region Week Three
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeMonday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[14]), Convert.ToInt32(strMonths[14]), Convert.ToInt32(strDays[14]));
                new FrmCalendarActivities(dt).ShowDialog();   
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeTuesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[15]), Convert.ToInt32(strMonths[15]), Convert.ToInt32(strDays[15]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeWednesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[16]), Convert.ToInt32(strMonths[16]), Convert.ToInt32(strDays[16]));
                new FrmCalendarActivities(dt).ShowDialog();   
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeThursday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[17]), Convert.ToInt32(strMonths[17]), Convert.ToInt32(strDays[17]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeFriday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[18]), Convert.ToInt32(strMonths[18]), Convert.ToInt32(strDays[18]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeSaturday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[19]), Convert.ToInt32(strMonths[19]), Convert.ToInt32(strDays[19]));
                new FrmCalendarActivities(dt).ShowDialog();   
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeSunday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[20]), Convert.ToInt32(strMonths[20]), Convert.ToInt32(strDays[20]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }
            #endregion

            #region Week Four
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourMonday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[21]), Convert.ToInt32(strMonths[21]), Convert.ToInt32(strDays[21]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourTuesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[22]), Convert.ToInt32(strMonths[22]), Convert.ToInt32(strDays[22]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourWednesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[23]), Convert.ToInt32(strMonths[23]), Convert.ToInt32(strDays[23]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourThursday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[24]), Convert.ToInt32(strMonths[24]), Convert.ToInt32(strDays[24]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourFriday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[25]), Convert.ToInt32(strMonths[25]), Convert.ToInt32(strDays[25]));
                new FrmCalendarActivities(dt).ShowDialog();   
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourSaturday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[26]), Convert.ToInt32(strMonths[26]), Convert.ToInt32(strDays[26]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourSunday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[27]), Convert.ToInt32(strMonths[27]), Convert.ToInt32(strDays[27]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }
            #endregion

            #region Week Five
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveMonday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[28]), Convert.ToInt32(strMonths[28]), Convert.ToInt32(strDays[28]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveTuesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[29]), Convert.ToInt32(strMonths[29]), Convert.ToInt32(strDays[29]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveWednesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[30]), Convert.ToInt32(strMonths[30]), Convert.ToInt32(strDays[30]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveThursday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[31]), Convert.ToInt32(strMonths[31]), Convert.ToInt32(strDays[31]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveFriday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[32]), Convert.ToInt32(strMonths[32]), Convert.ToInt32(strDays[32]));
                new FrmCalendarActivities(dt).ShowDialog();  
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveSaturday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[33]), Convert.ToInt32(strMonths[33]), Convert.ToInt32(strDays[33]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveSunday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[34]), Convert.ToInt32(strMonths[34]), Convert.ToInt32(strDays[34]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }
            #endregion

            #region Week Six
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixMonday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[35]), Convert.ToInt32(strMonths[35]), Convert.ToInt32(strDays[35]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixTuesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[36]), Convert.ToInt32(strMonths[36]), Convert.ToInt32(strDays[36]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixWednesday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[37]), Convert.ToInt32(strMonths[37]), Convert.ToInt32(strDays[37]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixThursday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[38]), Convert.ToInt32(strMonths[38]), Convert.ToInt32(strDays[38]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixFriday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[39]), Convert.ToInt32(strMonths[39]), Convert.ToInt32(strDays[39]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixSaturday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[40]), Convert.ToInt32(strMonths[40]), Convert.ToInt32(strDays[40]));
                new FrmCalendarActivities(dt).ShowDialog(); 
               
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixSunday")
            {
                DateTime dt = new DateTime(Convert.ToInt32(strYears[41]), Convert.ToInt32(strMonths[41]), Convert.ToInt32(strDays[41]));
                new FrmCalendarActivities(dt).ShowDialog(); 
            }
            #endregion
        }

        private void CurrentDaySetting(int Year, int Month, int Day)
        {
            if (Year == DateTime.Now.Year && Month == DateTime.Now.Month && Day == DateTime.Now.Day)
            {
                fontStyle = FontStyle.Bold;
                dateFontSize = 18;
                brush = Brushes.Black;
            }
        }

        private void ResetDaySetting()
        {
            fontStyle = FontStyle.Regular;
            dateFontSize = 14;
            brush = Brushes.Green;
        }

        private void PaintInformation(object sender, PaintEventArgs e)
        {            

            #region Week One
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneMonday")
            {              
                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    CurrentDaySetting(Convert.ToInt32(strYears[0]), Convert.ToInt32(strMonths[0]), Convert.ToInt32(strDays[0]));
                    e.Graphics.DrawString(strDays[0], myFont, brush, new Point(2, 2));                    
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[0], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneTuesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[1]), Convert.ToInt32(strMonths[1]), Convert.ToInt32(strDays[1]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[1], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[1], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneWednesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[2]), Convert.ToInt32(strMonths[2]), Convert.ToInt32(strDays[2]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[2], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[2], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneThursday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[3]), Convert.ToInt32(strMonths[3]), Convert.ToInt32(strDays[3]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[3], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[3], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneFriday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[4]), Convert.ToInt32(strMonths[4]), Convert.ToInt32(strDays[4]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[4], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[4], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneSaturday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[5]), Convert.ToInt32(strMonths[5]), Convert.ToInt32(strDays[5]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[5], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[5], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekOneSunday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[6]), Convert.ToInt32(strMonths[6]), Convert.ToInt32(strDays[6]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[6], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[6], myFont, brush, new Point(2, 25));
                }
            }
            #endregion

            #region Week Two
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoMonday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[7]), Convert.ToInt32(strMonths[7]), Convert.ToInt32(strDays[7]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[7], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[7], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoTuesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[8]), Convert.ToInt32(strMonths[8]), Convert.ToInt32(strDays[8]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[8], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[8], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoWednesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[9]), Convert.ToInt32(strMonths[9]), Convert.ToInt32(strDays[9]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[9], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[9], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoThursday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[10]), Convert.ToInt32(strMonths[10]), Convert.ToInt32(strDays[10]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[10], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[10], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoFriday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[11]), Convert.ToInt32(strMonths[11]), Convert.ToInt32(strDays[11]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[11], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[11], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoSaturday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[12]), Convert.ToInt32(strMonths[12]), Convert.ToInt32(strDays[12]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[12], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[12], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekTwoSunday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[13]), Convert.ToInt32(strMonths[13]), Convert.ToInt32(strDays[13]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[13], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[13], myFont, brush, new Point(2, 25));
                }
            }
            #endregion

            #region Week Three
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeMonday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[14]), Convert.ToInt32(strMonths[14]), Convert.ToInt32(strDays[14]));
                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[14], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[14], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeTuesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[15]), Convert.ToInt32(strMonths[15]), Convert.ToInt32(strDays[15]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[15], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[15], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeWednesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[16]), Convert.ToInt32(strMonths[16]), Convert.ToInt32(strDays[16]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[16], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[16], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeThursday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[17]), Convert.ToInt32(strMonths[17]), Convert.ToInt32(strDays[17]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[17], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[17], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeFriday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[18]), Convert.ToInt32(strMonths[18]), Convert.ToInt32(strDays[18]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[18], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[18], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeSaturday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[19]), Convert.ToInt32(strMonths[19]), Convert.ToInt32(strDays[19]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[19], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[19], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekThreeSunday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[20]), Convert.ToInt32(strMonths[20]), Convert.ToInt32(strDays[20]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[20], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[20], myFont, brush, new Point(2, 25));
                }
            }
            #endregion

            #region Week Four
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourMonday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[21]), Convert.ToInt32(strMonths[21]), Convert.ToInt32(strDays[21]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[21], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[21], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourTuesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[22]), Convert.ToInt32(strMonths[22]), Convert.ToInt32(strDays[22]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[22], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[22], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourWednesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[23]), Convert.ToInt32(strMonths[23]), Convert.ToInt32(strDays[23]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[23], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[23], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourThursday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[24]), Convert.ToInt32(strMonths[24]), Convert.ToInt32(strDays[24]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[24], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[24], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourFriday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[25]), Convert.ToInt32(strMonths[25]), Convert.ToInt32(strDays[25]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[25], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[25], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourSaturday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[26]), Convert.ToInt32(strMonths[26]), Convert.ToInt32(strDays[26]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[26], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[26], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFourSunday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[27]), Convert.ToInt32(strMonths[27]), Convert.ToInt32(strDays[27]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[27], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[27], myFont, brush, new Point(2, 25));
                }
            }
            #endregion

            #region Week Five
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveMonday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[28]), Convert.ToInt32(strMonths[28]), Convert.ToInt32(strDays[28]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[28], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[28], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveTuesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[29]), Convert.ToInt32(strMonths[29]), Convert.ToInt32(strDays[29]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[29], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[29], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveWednesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[30]), Convert.ToInt32(strMonths[30]), Convert.ToInt32(strDays[30]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[30], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[30], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveThursday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[31]), Convert.ToInt32(strMonths[31]), Convert.ToInt32(strDays[31]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[31], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[31], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveFriday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[32]), Convert.ToInt32(strMonths[32]), Convert.ToInt32(strDays[32]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[32], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[32], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveSaturday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[33]), Convert.ToInt32(strMonths[33]), Convert.ToInt32(strDays[33]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[33], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[33], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekFiveSunday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[34]), Convert.ToInt32(strMonths[34]), Convert.ToInt32(strDays[34]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[34], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[34], myFont, brush, new Point(2, 25));
                }
            }
            #endregion

            #region Week Six
            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixMonday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[35]), Convert.ToInt32(strMonths[35]), Convert.ToInt32(strDays[35]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[35], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[35], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixTuesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[36]), Convert.ToInt32(strMonths[36]), Convert.ToInt32(strDays[36]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[36], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[36], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixWednesday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[37]), Convert.ToInt32(strMonths[37]), Convert.ToInt32(strDays[37]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[37], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[37], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixThursday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[38]), Convert.ToInt32(strMonths[38]), Convert.ToInt32(strDays[38]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[38], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[38], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixFriday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[39]), Convert.ToInt32(strMonths[39]), Convert.ToInt32(strDays[39]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[39], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[39], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixSaturday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[40]), Convert.ToInt32(strMonths[40]), Convert.ToInt32(strDays[40]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[40], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[40], myFont, brush, new Point(2, 25));
                }
            }

            if (((System.Windows.Forms.Control)(sender)).Name == "WeeekSixSunday")
            {
                CurrentDaySetting(Convert.ToInt32(strYears[41]), Convert.ToInt32(strMonths[41]), Convert.ToInt32(strDays[41]));

                using (Font myFont = new Font(dateFontName, dateFontSize, fontStyle))
                {
                    e.Graphics.DrawString(strDays[41], myFont, brush, new Point(2, 2));
                }

                using (Font myFont = new Font("Tahoma", 8))
                {
                    e.Graphics.DrawString("Profiles Count: " + strRecordsCount[41], myFont, brush, new Point(2, 25));
                }
            }
            #endregion

            ResetDaySetting();
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dateInOperation = dateInOperation.AddMonths(-1);

            this.Invalidate();
            this.Update();
            this.Refresh();
            DisposeControls();
            InitializeInformation();

            lblMonthDetails.Text = dateInOperation.ToString("MMMM yyyy");
            lblMonthDetails.Refresh();

            Cursor.Current = Cursors.Arrow;
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dateInOperation = dateInOperation.AddMonths(1);                      

            this.Invalidate();
            this.Update();
            this.Refresh();
            DisposeControls();
            InitializeInformation();

            lblMonthDetails.Text = dateInOperation.ToString("MMMM yyyy");
            lblMonthDetails.Refresh();

            Cursor.Current = Cursors.Arrow;
        }
    }
}
