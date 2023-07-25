using System;
using System.Linq;
using Xunit;
using Cims.WorkflowLib.Miscellaneous;

namespace Cims.Tests.WorkflowLib.Miscellaneous
{
    public class TrickyScheduleTest
    {
        #region Testing constructors
        [Fact]
        public void Constructor_DefaultConstructor_IsForEveryTrue()
        {
            TrickySchedule schedule = new TrickySchedule(); 

            Assert.True(schedule.ScheduleInfo.Years.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Months.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Days.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.DayOfWeek.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Hours.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Minutes.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Seconds.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.IsForEvery); 
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("IncorrectString")]
        [InlineData("*.*.* *_*:*:*.*")]
        [InlineData("*-*.*.* * *:*:*.*")]
        [InlineData("*.-*.* * *:*:*.*")]
        [InlineData("*.*.+* * *:*:*.*")]
        [InlineData("*.*.+* *:*:*.*")]
        [InlineData("*:*:*.0*")]
        [InlineData("*:*:!*.*")]
        [InlineData("**:*:*.*")]
        [InlineData("*:*34:*.*")]
        public void Constructor_InvalidScheduleString_ThrowsException(string scheduleString)
        {
            Action act = () => new TrickySchedule(scheduleString); 
            System.Exception ex = Assert.Throws<System.Exception>(act);
        }

        [Theory]
        [InlineData("*.*.* * *:*:*.*")]
        [InlineData("*.*.* * *:*:*")]
        [InlineData("*.*.* *:*:*.*")]
        [InlineData("*.*.* *:*:*")]
        [InlineData("*:*:*.*")]
        [InlineData("*:*:*")]
        public void Constructor_ScheduleStringForEveryMillisecond_IsForEveryTrue(string scheduleString)
        {
            TrickySchedule schedule = new TrickySchedule(scheduleString); 

            Assert.True(schedule.ScheduleInfo.Years.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Months.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Days.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.DayOfWeek.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Hours.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Minutes.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Seconds.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.IsForEvery); 
        }

        [Fact]
        public void Constructor_ListsRangesAndDivision_DaysStoredInArray()
        {
            // Arrange 
            string scheduleString = "*.*.1,2,3-5,10-20/3 *:*:*.*"; 
            int[] expectedDays = { 1,2,3,4,5,10,13,16,19 }; 
            bool areDaysEqual = true; 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 

            // Assert IsForEvery 
            Assert.True(schedule.ScheduleInfo.Years.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Months.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Days.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.DayOfWeek.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Hours.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Minutes.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Seconds.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.IsForEvery); 

            // Assert array items 
            Assert.Equal(expectedDays.Length, schedule.ScheduleInfo.Days.Values.Length); 
            foreach (int day in schedule.ScheduleInfo.Days.Values)
            {
                if (expectedDays.Where(x => x == day).ToList().Count != 1)
                {
                    areDaysEqual = false; 
                    break; 
                }
            }
            if (areDaysEqual)
            {
                foreach (int day in expectedDays)
                {
                    if (schedule.ScheduleInfo.Days.Values.Where(x => x == day).ToList().Count != 1)
                    {
                        areDaysEqual = false; 
                        break; 
                    }
                }
            }
            Assert.True(areDaysEqual); 
        }

        [Fact]
        public void Constructor_MondayToFridayInSeptemberOnlyOddDays_AllStoredInArrayExceptYears()
        {
            string scheduleString = "*.9.*/2 1-5 10:00:00.000"; 
            int[] expectedDays = { 1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31 }; 
            int[] expectedDaysOfWeek = { 1,2,3,4,5 }; 
            bool areDaysEqual = true; 
            bool areDaysOfWeekEqual = true; 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 

            Assert.True(schedule.ScheduleInfo.Years.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Months.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Days.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.DayOfWeek.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Hours.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Minutes.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Seconds.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Milliseconds.IsForEvery); 

            Assert.True(schedule.ScheduleInfo.Months.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Months.Values.Where(x => x == 9).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Hours.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Hours.Values.Where(x => x == 10).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Minutes.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Minutes.Values.Where(x => x == 0).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Seconds.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Seconds.Values.Where(x => x == 0).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.Values.Where(x => x == 0).ToList().Count == 1); 

            Assert.Equal(expectedDays.Length, schedule.ScheduleInfo.Days.Values.Length); 
            foreach (int day in schedule.ScheduleInfo.Days.Values)
            {
                if (expectedDays.Where(x => x == day).ToList().Count != 1)
                {
                    areDaysEqual = false; 
                    break; 
                }
            }
            if (areDaysEqual)
            {
                foreach (int day in expectedDays)
                {
                    if (schedule.ScheduleInfo.Days.Values.Where(x => x == day).ToList().Count != 1)
                    {
                        areDaysEqual = false; 
                        break; 
                    }
                }
            }
            Assert.True(areDaysEqual); 

            Assert.Equal(expectedDaysOfWeek.Length, schedule.ScheduleInfo.DayOfWeek.Values.Length); 
            foreach (int day in schedule.ScheduleInfo.DayOfWeek.Values)
            {
                if (expectedDaysOfWeek.Where(x => x == day).ToList().Count != 1)
                {
                    areDaysOfWeekEqual = false; 
                    break; 
                }
            }
            if (areDaysOfWeekEqual)
            {
                foreach (int day in expectedDaysOfWeek)
                {
                    if (schedule.ScheduleInfo.DayOfWeek.Values.Where(x => x == day).ToList().Count != 1)
                    {
                        areDaysOfWeekEqual = false; 
                        break; 
                    }
                }
            }
            Assert.True(areDaysEqual); 
        }

        [Fact]
        public void Constructor_BeginningOfEveryHour_MinutesAndSecondsStoredInArrays()
        {
            string scheduleString = "*:00:00"; 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 

            Assert.True(schedule.ScheduleInfo.Years.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Months.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Days.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.DayOfWeek.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Hours.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Minutes.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Seconds.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.IsForEvery); 

            Assert.True(schedule.ScheduleInfo.Minutes.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Minutes.Values.Where(x => x == 0).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Seconds.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Seconds.Values.Where(x => x == 0).ToList().Count == 1); 
        }

        [Fact]
        public void Constructor_FirstDayOfMonthsOneThirty_AllStoredInArraysExceptYearsAndMonths()
        {
            string scheduleString = "*.*.01 01:30:00"; 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 

            Assert.True(schedule.ScheduleInfo.Years.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Months.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Days.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.DayOfWeek.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Hours.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Minutes.IsForEvery); 
            Assert.False(schedule.ScheduleInfo.Seconds.IsForEvery); 
            Assert.True(schedule.ScheduleInfo.Milliseconds.IsForEvery); 

            Assert.True(schedule.ScheduleInfo.Days.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Days.Values.Where(x => x == 1).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Hours.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Hours.Values.Where(x => x == 1).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Minutes.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Minutes.Values.Where(x => x == 30).ToList().Count == 1); 
            Assert.True(schedule.ScheduleInfo.Seconds.Values.Length == 1); 
            Assert.True(schedule.ScheduleInfo.Seconds.Values.Where(x => x == 0).ToList().Count == 1); 
        }
        #endregion  // Testing constructors

        #region Getting next event 
        [Theory]
        [InlineData("*.*.* * *:*:*.*")]
        [InlineData("*.*.* * *:*:*")]
        [InlineData("*.*.* *:*:*.*")]
        [InlineData("*.*.* *:*:*")]
        [InlineData("*:*:*.*")]
        [InlineData("*:*:*")]
        public void NearestEvent_PassAssteriskParams_SystemDateTimeNowIsFound(string scheduleString)
        {
            // Arrange 
            var expected = System.DateTime.Now; 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NearestEvent(expected); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(expected.Second, actual.Second); 
            Assert.Equal(expected.Millisecond, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:*:*.*")]
        [InlineData("*.*.* * *:*:*")]
        [InlineData("*.*.* *:*:*.*")]
        [InlineData("*.*.* *:*:*")]
        [InlineData("*:*:*.*")]
        [InlineData("*:*:*")]
        public void NextEvent_PassAssteriskParams_MillisecondsIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddMilliseconds(1); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(expected.Second, actual.Second); 
            Assert.Equal(expected.Millisecond, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:*:*.0")]
        [InlineData("*.*.* *:*:*.0")]
        [InlineData("*:*:*.0")]
        public void NextEvent_PassAssteriskParamsExceptMilliseconds_SecondsIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddSeconds(1); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(expected.Second, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:*:0.0")]
        [InlineData("*.*.* *:*:0.0")]
        [InlineData("*:*:0.0")]
        public void NextEvent_PassAssteriskParamsExceptSeconds_MinutesIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddMinutes(1); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:0:0.0")]
        [InlineData("*.*.* *:0:0.0")]
        [InlineData("*:0:0.0")]
        public void NextEvent_PassAssteriskParamsExceptMinutes_HoursIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddHours(1); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * 0:0:0.0")]
        [InlineData("*.*.* 0:0:0.0")]
        [InlineData("0:0:0.0")]
        public void NextEvent_PassAssteriskParamsExceptHours_DaysIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddDays(1); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(0, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.1 * 0:0:0.0")]
        [InlineData("*.*.1 0:0:0.0")]
        public void NextEvent_PassAssteriskParamsExceptDays_MonthsIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddMonths(1).AddDays(-(input.Day - 1)); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(0, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.1.1 * 0:0:0.0")]
        [InlineData("*.1.1 0:0:0.0")]
        public void NextEvent_PassAssteriskParamsExceptMonths_YearsIncremented(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddYears(1).AddMonths(-(input.Month - 1)).AddDays(-(input.Day - 1)); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NextEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(0, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }
        #endregion  // Getting next event 

        #region Getting previous event 
        [Theory]
        [InlineData("*.*.* * *:*:*.*")]
        [InlineData("*.*.* * *:*:*")]
        [InlineData("*.*.* *:*:*.*")]
        [InlineData("*.*.* *:*:*")]
        [InlineData("*:*:*.*")]
        [InlineData("*:*:*")]
        public void NearestPrevEvent_PassAssteriskParams_SystemDateTimeNowIsFound(string scheduleString)
        {
            // Arrange 
            var expected = System.DateTime.Now; 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.NearestPrevEvent(expected); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(expected.Second, actual.Second); 
            Assert.Equal(expected.Millisecond, actual.Millisecond); 
        }

        
        [Theory]
        [InlineData("*.*.* * *:*:*.*")]
        [InlineData("*.*.* * *:*:*")]
        [InlineData("*.*.* *:*:*.*")]
        [InlineData("*.*.* *:*:*")]
        [InlineData("*:*:*.*")]
        [InlineData("*:*:*")]
        public void PrevEvent_PassAssteriskParams_MillisecondsEqualToZero(string scheduleString)
        {
            // Arrange 
            var input = System.DateTime.Now; 
            var expected = input.AddMilliseconds(-1); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(expected.Second, actual.Second); 
            Assert.Equal(expected.Millisecond, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:*:*.0")]
        [InlineData("*.*.* *:*:*.0")]
        [InlineData("*:*:*.0")]
        public void PrevEvent_PassAssteriskParamsExceptMilliseconds_MillisecondsEqualToZero(string scheduleString)
        {
            // Arrange 
            var input = new System.DateTime(2023, 7, 8, 12, 34, 45, 345); 
            var expected = input.AddMilliseconds(-input.Millisecond); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(expected.Minute, actual.Minute); 
            Assert.Equal(expected.Second, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:*:0.0")]
        [InlineData("*.*.* *:*:0.0")]
        [InlineData("*:*:0.0")]
        public void PrevEvent_PassAssteriskParamsExceptSeconds_SecondsEqualToZero(string scheduleString)
        {
            // Arrange 
            var input = new System.DateTime(2023, 7, 8, 12, 34, 45, 345); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(input.Year, actual.Year); 
            Assert.Equal(input.Month, actual.Month); 
            Assert.Equal(input.Day, actual.Day); 
            Assert.Equal(input.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(input.Hour, actual.Hour); 
            Assert.Equal(input.Minute, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * *:0:0.0")]
        [InlineData("*.*.* *:0:0.0")]
        [InlineData("*:0:0.0")]
        public void PrevEvent_PassAssteriskParamsExceptMinutes_MinutesEqualToZero(string scheduleString)
        {
            // Arrange 
            var input = new System.DateTime(2023, 7, 8, 12, 34, 45, 345); 
            var expected = input.AddMinutes(-input.Minute).AddSeconds(-input.Second).AddMilliseconds(-input.Millisecond); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(expected.Hour, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.* * 0:0:0.0")]
        [InlineData("*.*.* 0:0:0.0")]
        [InlineData("0:0:0.0")]
        public void PrevEvent_PassAssteriskParamsExceptHours_HoursEqualToZero(string scheduleString)
        {
            // Arrange 
            var input = new System.DateTime(2023, 7, 8, 12, 34, 45, 345); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(input.Year, actual.Year); 
            Assert.Equal(input.Month, actual.Month); 
            Assert.Equal(input.Day, actual.Day); 
            Assert.Equal(input.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(0, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.*.1 * 0:0:0.0")]
        [InlineData("*.*.1 0:0:0.0")]
        public void PrevEvent_PassAssteriskParamsExceptDays_HoursEqualToZeroAndFirstDayOfMonth(string scheduleString)
        {
            // Arrange 
            var input = new System.DateTime(2023, 7, 8, 12, 34, 45, 345); 
            var expected = input.AddDays(-(input.Day - 1)); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(0, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }

        [Theory]
        [InlineData("*.1.1 * 0:0:0.0")]
        [InlineData("*.1.1 0:0:0.0")]
        public void PrevEvent_PassAssteriskParamsExceptMonths_HoursEqualToZeroAndFirstDayOfYear(string scheduleString)
        {
            // Arrange 
            var input = new System.DateTime(2023, 7, 8, 12, 34, 45, 345); 
            var expected = input.AddMonths(-(input.Month - 1)).AddDays(-(input.Day - 1)); 
            TrickySchedule schedule = new TrickySchedule(scheduleString); 
            
            // Act
            var actual = schedule.PrevEvent(input); 

            // Assert
            Assert.Equal(expected.Year, actual.Year); 
            Assert.Equal(expected.Month, actual.Month); 
            Assert.Equal(expected.Day, actual.Day); 
            Assert.Equal(expected.DayOfWeek, actual.DayOfWeek); 
            Assert.Equal(0, actual.Hour); 
            Assert.Equal(0, actual.Minute); 
            Assert.Equal(0, actual.Second); 
            Assert.Equal(0, actual.Millisecond); 
        }
        #endregion  // Getting previous event 
    }
}
