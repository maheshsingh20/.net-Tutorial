using System;
using System.Collections.Generic;
namespace Attendance
{
  public class AttendanceCounter
  {
    public static Dictionary<string, int> GetAttendanceCount(List<int> list)
    {
      Dictionary<string, int> attendanceCount = new Dictionary<string, int>();
      for (int i = 0; i < list.Count; i++)
      {
        if (attendanceCount.ContainsKey(list[i].ToString()))
        {
          attendanceCount[list[i].ToString()]++;
        }
        else
        {
          attendanceCount.Add(list[i].ToString(), 1);
        }
      }
      return attendanceCount;
    }
    //Return student name with login attemp failed more than 3 times
    public void getFailedLoginAttempt(List<string> list)
    {
      Dictionary<string, int> Freq = new Dictionary<string, int>();
      foreach (var i in list)
      {
        if (Freq.ContainsKey(i))
        {
          Freq[i]++;
        }
        else
        {
          Freq.Add(i, 1);
        }
      }
      foreach(var i in Freq)
      {
        if (i.Value > 3)
        {
          Console.WriteLine("Student name: " + i.Key);
        }
      }
    }
  }
}
