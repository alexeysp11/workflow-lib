using System;
using System.Linq;
using System.Collections.Generic;

namespace Cims.WorkflowLib.Miscellaneous
{
	/// <summary>
	/// Class for storing information about a point in the schedule. 
	/// </summary>
	public class DateTimeElement
	{
		public int[] Values { get; set; }
		public bool IsForEvery { get; set; }
		public int MinValue { get; set; }
		public int MaxValue { get; set; }
	}

	/// <summary>
	/// Class for storing information on possible points in the schedule.
	/// </summary>
	public class ScheduleInfo 
	{
		public DateTimeElement Years { get; set; } 
		public DateTimeElement Months { get; set; } 
		public DateTimeElement Days { get; set; } 
		public DateTimeElement DayOfWeek { get; set; } 
		public DateTimeElement Hours { get; set; } 
		public DateTimeElement Minutes { get; set; } 
		public DateTimeElement Seconds { get; set; } 
		public DateTimeElement Milliseconds { get; set; } 
	}

	/// <summary>
	/// Class for setting and calculating time according to the schedule.
	/// </summary>
	public class TrickySchedule
	{
		/// <summary>
		/// Property for storing information on possible points in the schedule.
		/// </summary>
        public ScheduleInfo ScheduleInfo { get; private set; }

		#region Constructors
		/// <summary>
		/// Creates an empty instance that will match
		/// schedule of pattern "*.*.* * *:*:*.*" (once every 1 ms).
		/// </summary>
		public TrickySchedule() : this("*.*.* * *:*:*.*")
		{
		}

		/// <summary>
		/// Creates an instance from a string with a schedule representation.
		/// </summary>
		/// <param name="scheduleString">String with a schedule representation.
		/// String format:
		///     yyyy.MM.dd w HH:mm:ss.fff
		///     yyyy.MM.dd HH:mm:ss.fff
		///     HH:mm:ss.fff
		///     yyyy.MM.dd w HH:mm:ss
		///     yyyy.MM.dd HH:mm:ss
		///     HH:mm:ss
		/// Где yyyy - year (2000-2100)
		///     MM - month (1-12)
		///     dd - day in a month (1-31 или 32). 32 means the last day in a month
		///     w - day of week (0-6). 0 - sunday, 6 - satturday
		///     HH - hours (0-23)
		///     mm - minutes (0-59)
		///     ss - seconds (0-59)
		///     fff - milliseconds (0-999).
		/// Each part of the date/time can be specified as lists and ranges.
		/// For example:
		///     1,2,3-5,10-20/3
		///     means a list: 1,2,3,4,5,10,13,16,19
		/// The fraction sets the step in the list.
		/// An asterisk means any possible value.
		/// For example (for hours):
		///     */4
		///     means 0,4,8,12,16,20
		/// Instead of a list of numbers of the month, you can specify 32. This means the last
		/// number of any month.
		/// Example:
		/// 	*.9.*/2 1-5 10:00:00.000
		/// 	means 10:00 on all days from Mon. by Fri. on odd dates in September
		/// 	*:00:00
		/// 	means the beginning of any hour
		/// 	*.*.01 01:30:00
		/// 	means 01:30 on the first of every month
		/// </param>
		public TrickySchedule(string scheduleString)
		{
			if (string.IsNullOrEmpty(scheduleString)) 
				throw new System.Exception("Input parameter could not be null or empty"); 

			ScheduleInfo = new ScheduleInfo
			{
				Years = new DateTimeElement { MinValue = 2000, MaxValue = 2100 },
				Months = new DateTimeElement { MinValue = 1, MaxValue = 12 },
				Days = new DateTimeElement { MinValue = 1, MaxValue = 31 },
				DayOfWeek = new DateTimeElement { MinValue = 0, MaxValue = 6 },
				Hours = new DateTimeElement { MinValue = 0, MaxValue = 23 },
				Minutes = new DateTimeElement { MinValue = 0, MaxValue = 59 },
				Seconds = new DateTimeElement { MinValue = 0, MaxValue = 59 },
				Milliseconds = new DateTimeElement { MinValue = 0, MaxValue = 999 }
			};
			if (scheduleString == "*.*.* * *:*:*.*")
			{
				ScheduleInfo.Years.IsForEvery = true; 
				ScheduleInfo.Months.IsForEvery = true; 
				ScheduleInfo.Days.IsForEvery = true; 
				ScheduleInfo.DayOfWeek.IsForEvery = true; 
				ScheduleInfo.Hours.IsForEvery = true; 
				ScheduleInfo.Minutes.IsForEvery = true; 
				ScheduleInfo.Seconds.IsForEvery = true; 
				ScheduleInfo.Milliseconds.IsForEvery = true; 
			}
			else
			{
				var parts = scheduleString.Split(' '); 
				if (parts.Length == 0 || parts.Length > 3) 
					throw new System.Exception("Incorrect number of parts of input parameter"); 
				ParseTime(parts.Last()); 
				if (parts.Length != 1)
				{
					ParseDate(parts.First()); 
					if (parts.Length == 3)
						ParseDayOfWeek(parts[1]); 
					else
						ScheduleInfo.DayOfWeek.IsForEvery = true; 
				}
				else
				{
					ScheduleInfo.Years.IsForEvery = true; 
					ScheduleInfo.Months.IsForEvery = true; 
					ScheduleInfo.Days.IsForEvery = true; 
					ScheduleInfo.DayOfWeek.IsForEvery = true; 
				}
			}
		}
		#endregion	// Constructors

		#region Public methods
		/// <summary>
		/// Returns the next closest moment in the schedule to the specified time, or
		/// the specified time itself, if it is in the schedule.
		/// </summary>
		/// <param name="t1">Input time</param>
		/// <returns>The next time on the schedule</returns>
		public DateTime NearestEvent(DateTime t1)
		{
			// If IsForEvery is false and there's no such DateTime property in the Values array, 
			// then find the next element in the schedule. 
			// Otherwise, return the same object. 
			if (!ScheduleInfo.Years.IsForEvery && ScheduleInfo.Years.Values.Where(x => x == t1.Year).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.Months.IsForEvery && ScheduleInfo.Months.Values.Where(x => x == t1.Month).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.Days.IsForEvery && ScheduleInfo.Days.Values.Where(x => x == t1.Day).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.DayOfWeek.IsForEvery && ScheduleInfo.DayOfWeek.Values.Where(x => x == (int)t1.DayOfWeek).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.Hours.IsForEvery && ScheduleInfo.Hours.Values.Where(x => x == t1.Hour).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.Minutes.IsForEvery && ScheduleInfo.Minutes.Values.Where(x => x == t1.Minute).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.Seconds.IsForEvery && ScheduleInfo.Seconds.Values.Where(x => x == t1.Second).ToList().Count == 0)
				return NextEvent(t1); 
			if (!ScheduleInfo.Milliseconds.IsForEvery && ScheduleInfo.Milliseconds.Values.Where(x => x == t1.Millisecond).ToList().Count == 0)
				return NextEvent(t1); 
			return t1; 
		}

		/// <summary>
		/// Returns the previous closest moment in the schedule to the specified time, or
		/// the specified time itself, if it is in the schedule.
		/// </summary>
		/// <param name="t1">Input time</param>
		/// <returns>The previous closest moment in the schedule</returns>
		public DateTime NearestPrevEvent(DateTime t1)
		{
			// If IsForEvery is false and there's no such DateTime property in the Values array, 
			// then find the previous element in the schedule. 
			// Otherwise, return the same object. 
			if (!ScheduleInfo.Years.IsForEvery && ScheduleInfo.Years.Values.Where(x => x == t1.Year).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.Months.IsForEvery && ScheduleInfo.Months.Values.Where(x => x == t1.Month).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.Days.IsForEvery && ScheduleInfo.Days.Values.Where(x => x == t1.Day).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.DayOfWeek.IsForEvery && ScheduleInfo.DayOfWeek.Values.Where(x => x == (int)t1.DayOfWeek).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.Hours.IsForEvery && ScheduleInfo.Hours.Values.Where(x => x == t1.Hour).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.Minutes.IsForEvery && ScheduleInfo.Minutes.Values.Where(x => x == t1.Minute).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.Seconds.IsForEvery && ScheduleInfo.Seconds.Values.Where(x => x == t1.Second).ToList().Count == 0)
				return PrevEvent(t1); 
			if (!ScheduleInfo.Milliseconds.IsForEvery && ScheduleInfo.Milliseconds.Values.Where(x => x == t1.Millisecond).ToList().Count == 0)
				return PrevEvent(t1); 
			return t1; 
		}

		/// <summary>
		/// Returns the next point in time in the schedule.
		/// </summary>
		/// <param name="t1">Input time</param>
		/// <returns>The next time on the schedule</returns>
		public DateTime NextEvent(DateTime t1)
		{
			bool isFound = false; 
			int millisecond = FindNextDte(ScheduleInfo.Milliseconds, t1.Millisecond, out isFound); 
			if (millisecond > ScheduleInfo.Milliseconds.MaxValue)
				throw new System.Exception("Millisecond could not be bigger than allowed value"); 
			
			int second = isFound ? t1.Second : FindNextDte(ScheduleInfo.Seconds, t1.Second, out isFound); 
			if (second > ScheduleInfo.Seconds.MaxValue)
				throw new System.Exception("Second could not be bigger than allowed value"); 
			
			int minute = isFound ? t1.Minute : FindNextDte(ScheduleInfo.Minutes, t1.Minute, out isFound); 
			if (minute > ScheduleInfo.Minutes.MaxValue)
				throw new System.Exception("Minute could not be bigger than allowed value"); 
			
			int hour = isFound ? t1.Hour : FindNextDte(ScheduleInfo.Hours, t1.Hour, out isFound); 
			if (hour > ScheduleInfo.Hours.MaxValue)
				throw new System.Exception("Hour could not be bigger than allowed value"); 
			
			int day = isFound ? t1.Day : FindNextDte(ScheduleInfo.Days, t1.Day, out isFound); 
			if (day > ScheduleInfo.Days.MaxValue)
				throw new System.Exception("Day could not be bigger than allowed value"); 
			
			int month = isFound ? t1.Month : FindNextDte(ScheduleInfo.Months, t1.Month, out isFound); 
			if (month > ScheduleInfo.Months.MaxValue)
				throw new System.Exception("Month could not be bigger than allowed value"); 
			
			int year = isFound ? t1.Year : FindNextDte(ScheduleInfo.Years, t1.Year, out isFound); 
			if (year > ScheduleInfo.Years.MaxValue)
				throw new System.Exception("Year could not be bigger than allowed value"); 
			return new DateTime(year, month, day, hour, minute, second, millisecond); 
		}

		/// <summary>
		/// Returns the previous point in time in the schedule.
		/// </summary>
		/// <param name="t1">Input time</param>
		/// <returns>The previous point in time in the schedule</returns>
		public DateTime PrevEvent(DateTime t1)
		{
			int millisecond = FindPreviousDte(ScheduleInfo.Milliseconds, t1.Millisecond); 
			if (millisecond < ScheduleInfo.Milliseconds.MinValue)
				throw new System.Exception("Millisecond could not be less than allowed value"); 
			
			int second = ScheduleInfo.Seconds.IsForEvery ? t1.Second : FindPreviousDte(ScheduleInfo.Seconds, t1.Second); 
			if (second < ScheduleInfo.Seconds.MinValue)
				throw new System.Exception("Second could not be less than allowed value"); 
			
			int minute = ScheduleInfo.Minutes.IsForEvery ? t1.Minute : FindPreviousDte(ScheduleInfo.Minutes, t1.Minute); 
			if (minute < ScheduleInfo.Minutes.MinValue)
				throw new System.Exception("Minute could not be less than allowed value"); 
			
			int hour = ScheduleInfo.Hours.IsForEvery ? t1.Hour : FindPreviousDte(ScheduleInfo.Hours, t1.Hour); 
			if (hour < ScheduleInfo.Hours.MinValue)
				throw new System.Exception("Hour could not be less than allowed value"); 
			
			int day = ScheduleInfo.Days.IsForEvery ? t1.Day : FindPreviousDte(ScheduleInfo.Days, t1.Day); 
			if (day < ScheduleInfo.Days.MinValue)
				throw new System.Exception("Day could not be less than allowed value"); 
			
			int month = ScheduleInfo.Months.IsForEvery ? t1.Month : FindPreviousDte(ScheduleInfo.Months, t1.Month); 
			if (month < ScheduleInfo.Months.MinValue)
				throw new System.Exception("Month could not be less than allowed value"); 
			
			int year = ScheduleInfo.Years.IsForEvery ? t1.Year : FindPreviousDte(ScheduleInfo.Years, t1.Year); 
			if (year < ScheduleInfo.Years.MinValue)
				throw new System.Exception("Year could not be less than allowed value"); 
			return new DateTime(year, month, day, hour, minute, second, millisecond); 
		}
		#endregion	// Public methods

		#region Private parsing methods 
		/// <summary>
		/// Parsing of the time part of schedule string.
		/// </summary>
		/// <param name="scheduleString">String with a schedule representation.
		/// String format:
		///     HH:mm:ss.fff
		///     HH:mm:ss
		/// Где HH - hours (0-23)
		///     mm - minutes (0-59)
		///     ss - seconds (0-59)
		///     fff - milliseconds (0-999).
		/// </param>
		private void ParseTime(string scheduleString)
		{
			if (string.IsNullOrEmpty(scheduleString)) 
				throw new System.Exception("Input parameter could not be null or empty"); 
			
			var parts = scheduleString.Split(':'); 
			if (parts.Length != 3) 
				throw new System.Exception("Incorrect number of parts of input parameter"); 
			InitDateTimeElement(parts[0], ScheduleInfo.Hours); 
			InitDateTimeElement(parts[1], ScheduleInfo.Minutes); 
			parts = parts[2].Split('.'); 
			if (parts.Length > 2) 
				throw new System.Exception("Incorrect number of parts of input parameter"); 
			InitDateTimeElement(parts.First(), ScheduleInfo.Seconds); 
			if (parts.Length == 2)
				InitDateTimeElement(parts.Last(), ScheduleInfo.Milliseconds); 
			else 
				ScheduleInfo.Milliseconds.IsForEvery = true; 
		}

		/// <summary>
		/// Parsing of the date part of schedule string. 
		/// </summary>
		/// <param name="scheduleString">String with a schedule representation.
		/// String format:
		///     yyyy.MM.dd 
		/// Где yyyy - year (2000-2100)
		///     MM - month (1-12)
		///     dd - day in a month (1-31 или 32). 32 means the last day in a month.
		/// </param>
		private void ParseDate(string scheduleString)
		{
			if (string.IsNullOrEmpty(scheduleString)) 
				throw new System.Exception("Input parameter could not be null or empty"); 
			
			var parts = scheduleString.Split('.'); 
			if (parts.Length != 3) 
				throw new System.Exception("Incorrect number of parts of input parameter"); 
			// Initialize year 
			InitDateTimeElement(parts[0], ScheduleInfo.Years); 
			// Initialize month 
			InitDateTimeElement(parts[1], ScheduleInfo.Months); 
			// Initialize day 
			InitDateTimeElement(parts[2], ScheduleInfo.Days); 
		}

		/// <summary>
		/// Parsing of day of week. 
		/// </summary>
		/// <param name="scheduleString">String with a schedule representation.
		/// String format:
		///     w
		/// Где w - day of week (0-6). 0 - sunday, 6 - satturday
		/// </param>
		private void ParseDayOfWeek(string scheduleString)
		{
			if (string.IsNullOrEmpty(scheduleString)) 
				throw new System.Exception("Input parameter could not be null or empty"); 
			InitDateTimeElement(scheduleString, ScheduleInfo.DayOfWeek); 
		}

		/// <summary>
		/// General method for setting property values for DateTimeElement.
		/// </summary>
		/// <param name="scheduleString">Schedule string.
		/// Each part of the date/time can be specified as lists and ranges.
		/// For example:
		/// 	1,2,3-5,10-20/3
		/// 	means list 1,2,3,4,5,10,13,16,19
		/// The fraction sets the step in the list.
		/// An asterisk means any possible value.
		/// For example (for hours):
		///     */4
		/// 	means 0,4,8,12,16,20
		/// Instead of a list of numbers of the month, you can specify 32. This means the last
		/// number of any month.
		/// Example:
		/// 	*.9.*/2 1-5 10:00:00.000
		/// 	means 10:00 on all days from Mon. by Fri. on odd dates in September
		/// 	*:00:00
		/// 	means the beginning of any hour
		/// 	*.*.01 01:30:00
		/// 	means 01:30 on the first of every month
		/// </param>
		/// <param name="dte">Element containing information about points in the schedule.</param>
		private void InitDateTimeElement(string scheduleString, DateTimeElement dte)
		{
			var min = dte.MinValue; 
			var max = dte.MaxValue; 
			if (string.IsNullOrEmpty(scheduleString))
				throw new System.Exception("Input string could not be empty"); 
			if (dte == null)
				throw new System.Exception("DateTimeElement could not be null"); 
			if (min > max) 
				throw new System.Exception("min could not be greater than max"); 
			
			if (scheduleString == "*")
			{
				dte.IsForEvery = true; 
				return; 
			}
			var parts = scheduleString.Split(','); 
			List<int> list = new List<int>(); 
			foreach (var part in parts)
			{
				// value 
				if (!part.StartsWith("*/") && !part.Contains("-"))
				{
					ParseAndAdd(part, list, min, max); 
					continue; 
				}
				// */n
				if (part.StartsWith("*/"))
				{
					AddDateTimeAstriskNPart(part, list, min, max); 
					continue; 
				}
				// range
				AddDateTimeRange(part, list, min, max); 
			}
			dte.Values = list.ToArray(); 
		}

		/// <summary>
		/// Parsing the string if it contains an asterisk and a division.
		/// </summary>
		/// <param name="part">Part of the source string to be parsed.</param>
		/// <param name="list">List of values for points in the schedule.</param>
		/// <param name="min">Minimum allowable point value in the schedule.</param>
		/// <param name="max">The maximum allowable point value in the schedule.</param>
		private void AddDateTimeAstriskNPart(string part, List<int> list, int min, int max)
		{
			if (string.IsNullOrEmpty(part))
				throw new System.Exception("Input string could not be empty"); 
			if (min > max) 
				throw new System.Exception("min could not be greater than max"); 
			
			var intStr = part.Replace("*/", ""); 
			int delta; 
			if (!System.Int32.TryParse(intStr, out delta)) 
				throw new System.Exception("Unable to parse a range component"); 
			if (delta < 0)
				throw new System.Exception("Delta could not be negative"); 
			int value = min; 
			while (value <= max)
			{
				list.Add(value); 
				value += delta; 
			}
		}

		/// <summary>
		/// Method for adding a range.
		/// </summary>
		/// <param name="part">Part of the source string to be parsed.</param>
		/// <param name="list">List of values for points in the schedule.</param>
		/// <param name="min">Minimum allowable point value in the schedule.</param>
		/// <param name="max">The maximum allowable point value in the schedule.</param>
		private void AddDateTimeRange(string part, List<int> list, int min, int max)
		{
			if (string.IsNullOrEmpty(part))
				throw new System.Exception("Input string could not be empty"); 
			if (min > max) 
				throw new System.Exception("min could not be greater than max"); 
			
			var ranges = part.Split('-'); 
			if (ranges.Length != 2)
				throw new System.Exception("Incorrect number of range components"); 
			int rangeFrom, rangeTo, rangeDelta; 
			if (!System.Int32.TryParse(ranges.First(), out rangeFrom)) 
				throw new System.Exception("Unable to parse a range component"); 
			if (rangeFrom < min)
				throw new System.Exception("The starting point of a range could not be less than min"); 
			// End of a range could be represented using '/'
			var rangeToParts = ranges.Last().Split('/'); 
			if (rangeToParts.Length > 2)
				throw new System.Exception("Incorrect number of ends of a range"); 
			if (!System.Int32.TryParse(rangeToParts.First(), out rangeTo)) 
				throw new System.Exception("Unable to parse a range component"); 
			if (rangeTo > max)
				throw new System.Exception("The ending point of a range could not be greater than max"); 
			if (rangeToParts.Length == 1)
				rangeDelta = 1;
			else
			{
				if (!System.Int32.TryParse(rangeToParts.Last(), out rangeDelta)) 
					throw new System.Exception("Unable to parse a range component"); 
			}
			int value = rangeFrom; 
			while (value <= rangeTo)
			{
				list.Add(value); 
				value += rangeDelta; 
			}
		}

		/// <summary>
		/// General method for adding a point to the schedule.
		/// </summary>
		/// <param name="part">Part of the source string to be parsed.</param>
		/// <param name="list">List of values for points in the schedule.</param>
		/// <param name="min">Minimum allowable point value in the schedule.</param>
		/// <param name="max">The maximum allowable point value in the schedule.</param>
		private void ParseAndAdd(string part, List<int> list, int min, int max)
		{
			if (string.IsNullOrEmpty(part))
				throw new System.Exception("Input string could not be empty"); 
			if (min > max) 
				throw new System.Exception("min could not be greater than max"); 
			
			int value; 
			if (!System.Int32.TryParse(part, out value)) 
				throw new System.Exception("Unable to parse a part of scheduleString"); 
			if (value < min || value > max) 
				throw new System.Exception("Parsed value is out of bounds"); 
			list.Add(value); 
		}
		#endregion	// Private parsing methods 

		#region Private filtering methods 
		/// <summary>
		/// Finds the next possible point in the schedule.
		/// </summary>
		/// <param name="dte">Element containing information about points in the schedule.</param>
		/// <param name="referenceValue">Reference value of the point parameter in the schedule.</param>
		/// <param name="isFound">A boolean indicating whether a point was found in the schedule.</param>
		private int FindNextDte(DateTimeElement dte, int referenceValue, out bool isFound)
		{
			isFound = false; 
			int result = 0; 
			if (dte.IsForEvery)
			{
				if (referenceValue >= dte.MaxValue)
					result = dte.MinValue; 
				else 
				{
					result = referenceValue + 1; 
					isFound = true; 
				}
			}
			else
			{
				var ms = dte.Values.Where(x => x > referenceValue).ToList(); 
				if (ms.Count > 0)
				{
					result = ms.Min();
					isFound = true; 
				}
				else 
					result = dte.MinValue;
			}
			return result; 
		}

		/// <summary>
		/// Finds the previous point in the schedule.
		/// </summary>
		/// <param name="dte">Element containing information about points in the schedule.</param>
		/// <param name="referenceValue">Reference value of the point parameter in the schedule.</param>
		private int FindPreviousDte(DateTimeElement dte, int referenceValue)
		{
			int result = 0; 
			if (dte.IsForEvery)
			{
				if (referenceValue <= dte.MinValue)
					result = dte.MaxValue; 
				else 
					result = referenceValue - 1; 
			}
			else
			{
				var ms = dte.Values.Where(x => x < referenceValue).ToList(); 
				if (ms.Count > 0)
					result = ms.Max();
				else 
					result = dte.MaxValue;
			}
			return result; 
		}
		#endregion	// Private filtering methods 
	}
}