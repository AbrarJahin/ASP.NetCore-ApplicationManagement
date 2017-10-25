﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class EducationResult
    {
        [Key]
        public long Id { get; set; }

        public long TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual TeacherApplication Teacher { get; set; }

        public string ExamName { get; set; }
        public string BoardOrUniversity { get; set; }
        public string GroupOrSubject { get; set; }
        public UInt16 YearOfPassing { get; set; }
        public UInt16 YearOfExam { get; set; }
        public string DivisionOrClassOrGPAOrCGPA { get; set; }
        public string CertificatePdfFileUrl { get; set; }
        public string TranscriptPdfFileUrl { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        public EducationResult()
        {
            AddedDate = DateTime.UtcNow;
        }
    }
}
