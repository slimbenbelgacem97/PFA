﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 4/7/2021 11:58:15 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace backend.Models
{
    public partial class Exam {

        public Exam()
        {
            OnCreated();
        }

        public   string Convocation { get; set; }

        public   string List { get; set; }

        public     DateTime DateExam { get; set; }

        public   ExamType Type { get; set; }

        public     Candidat Candidat { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
