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
    public partial class Agent {

        public Agent()
        {
            this.Seances = new List<Seances>();
            OnCreated();
        }

        public  int AgentCIN { get; set; }

        public  string Nom { get; set; }

        public  string Prenom { get; set; }

        public  DateTime DateEmb { get; set; }

        public  string Adresse { get; set; }

        public  double Salaire { get; set; }

        public  AgentFunction Fonction { get; set; }

        public LoginAgents LoginAgent { get; set; }

        public Vehicle Vehicle { get; set; }

        public  IList<Seances> Seances { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
