﻿namespace GroupArchive.Models;

public class Group
{
    public Group(){}
    public Group(string studyYear, string specialization, int сourse, int number)
    {
        StudyYear = studyYear;
        Specialization = specialization ?? throw new ArgumentNullException(nameof(specialization));
        Сourse = сourse;
        Number = number;
    }

    public string StudyYear { get; set; }
    public string Specialization { get; set; }
    public int Сourse { get; set; }
    public int Number { get; set; }
}