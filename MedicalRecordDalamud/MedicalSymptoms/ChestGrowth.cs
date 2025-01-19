using Dalamud.IoC;
using Dalamud.Plugin.Services;
using PenumbraAndGlamourerHelpers;
using PenumbraAndGlamourerHelpers.IPC.ThirdParty.Glamourer;
using RoleplayingMedicalRecordCore.MedicalTracking;
using SamplePlugin;
using System;
using System.Numerics;

namespace MedicalRecordDalamud.MedicalSymptoms
{
    public class ChestGrowth : ISymptom
    {
        private string _name;
        private string _description;
        private DateTime _lastSymptomTreatment;
        private TimeSpan _timeUntilSymptomReturns;
        private bool _treatmentConditionMet;
        private int _chestVolume;
        private float _targetMultiplier;
        private float _multiplier;
        public ChestGrowth()
        {
            _lastSymptomTreatment = DateTime.Now;
            _timeUntilSymptomReturns = new TimeSpan(0, 0, 20);
            if (_targetMultiplier == 0)
            {
                _targetMultiplier = 0.1f;
            }
            _multiplier = 0;
        }


        public string Name => _name;

        public string Description => _description;

        public DateTime LastSymptomTreatment => _lastSymptomTreatment;

        public TimeSpan TimeUntilSymptomReturns => _timeUntilSymptomReturns;

        public bool TreatmentConditionMet => _treatmentConditionMet;

        public void ExecuteSymptomBehaviour()
        {
            var symptomReliefTime = (LastSymptomTreatment + TimeUntilSymptomReturns);
            if (symptomReliefTime < DateTime.Now)
            {
                if (_chestVolume == 100)
                {
                    PenumbraAndGlamourerHelperFunctions.SetEquipmentRaw(FullEquipType.Body, 0, Plugin.ClientState.LocalPlayer.ObjectIndex);
                    _targetMultiplier = (float)Math.Clamp(_targetMultiplier -= 0.01f, 0.001, double.MaxValue);
                }
                else
                {
                    var customization = PenumbraAndGlamourerHelperFunctions.GetCustomization(Plugin.ClientState.LocalPlayer);
                    _chestVolume = Math.Clamp((int)((float)(DateTime.Now - symptomReliefTime).TotalSeconds * _multiplier), 0, 100);
                    customization.Customize.BustSize.Value = _chestVolume;
                    PenumbraAndGlamourerHelperFunctions.SetCustomization(Plugin.ClientState.LocalPlayer, customization);
                    _multiplier = float.Lerp(_multiplier, _targetMultiplier, 0.5f);
                }
            }
            else
            {
                var customization = PenumbraAndGlamourerHelperFunctions.GetCustomization(Plugin.ClientState.LocalPlayer);
                customization.Customize.BustSize.Value = _chestVolume -= 5;
                PenumbraAndGlamourerHelperFunctions.SetCustomization(Plugin.ClientState.LocalPlayer, customization);
            }
        }

        public void TreatSymptom()
        {
            _lastSymptomTreatment = DateTime.Now;
            _targetMultiplier += 0.1f;
        }
        public void IncreaseSymptom()
        {
            _targetMultiplier += 0.3f;
        }
    }
}
