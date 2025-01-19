using MedicalRecordDalamud.MedicalSymptoms;
using RoleplayingMedicalRecordCore.MedicalManagment;
using RoleplayingMedicalRecordCore.MedicalTracking;
using System;
using System.Collections.Generic;

namespace MedicalRecordDalamud.MedicalConditions
{
    public class Gigantosis : MedicalCondition
    {
        public Gigantosis() : base("Lactosis",
            "Characterised by an excess production of milk.",
            false, false, DateTime.Now, new TimeSpan(5, 0, 0), new TimeSpan(10, 0, 0), new List<ISymptom>() { new ChestGrowth() })
        {

        }

    }
}
