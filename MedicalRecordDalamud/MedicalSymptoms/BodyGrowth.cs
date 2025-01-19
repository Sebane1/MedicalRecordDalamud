using RoleplayingMedicalRecordCore.MedicalTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordDalamud.MedicalSymptoms
{
    internal class BodyGrowth : ISymptom
    {
        private string _name;
        private string _description;
        private DateTime _lastSymptomTreatment;
        private TimeSpan _timeUntilSymptomReturns;
        private bool _treatmentConditionMet;

        public string Name => _name;

        public string Description => _description;

        public DateTime LastSymptomTreatment => _lastSymptomTreatment;

        public TimeSpan TimeUntilSymptomReturns => _timeUntilSymptomReturns;

        public bool TreatmentConditionMet => _treatmentConditionMet;

        public void ExecuteSymptomBehaviour()
        {
            throw new NotImplementedException();
        }

        public void IncreaseSymptom()
        {
            throw new NotImplementedException();
        }

        public void TreatSymptom()
        {
            throw new NotImplementedException();
        }
    }
}
