using MedicalRecordDalamud.MedicalSymptoms;
using RoleplayingMedicalRecordCore.MedicalManagment;
using RoleplayingMedicalRecordCore.MedicalTracking;
using SamplePlugin;
using System;
using System.Collections.Generic;

namespace MedicalRecordDalamud.MedicalConditions
{
    public class Lactosis : MedicalCondition
    {
        public Lactosis() : base("Lactosis",
            "Characterised by an excess production of milk.",
            false, false, DateTime.Now, new TimeSpan(5, 0, 0), new TimeSpan(10, 0, 0), new List<ISymptom>() { new ChestGrowth() })
        {
            Plugin.ChatGui.ChatMessage += ChatGui_ChatMessage;
        }

        private void ChatGui_ChatMessage(Dalamud.Game.Text.XivChatType type, int timestamp, ref Dalamud.Game.Text.SeStringHandling.SeString sender, ref Dalamud.Game.Text.SeStringHandling.SeString message, ref bool isHandled)
        {
            if (type == Dalamud.Game.Text.XivChatType.CustomEmote || type == Dalamud.Game.Text.XivChatType.TellIncoming)
            {
                if (message.TextValue.Contains("milk") || message.TextValue.Contains("milking") || message.TextValue.Contains("nurses")
                    || message.TextValue.Contains("suck") || message.TextValue.Contains("suckles") || message.TextValue.Contains("drains"))
                {
                    foreach (var item in Symptoms)
                    {
                        item.TreatSymptom();
                    }
                }
                if ((message.TextValue.Contains("massage") || message.TextValue.Contains("suck")
                    || message.TextValue.Contains("massaging") || message.TextValue.Contains("press")
                    || message.TextValue.Contains("finger") || message.TextValue.Contains("rub")
                    || message.TextValue.Contains("lick") || message.TextValue.Contains("impregnate")
                    || message.TextValue.Contains("grope") || message.TextValue.Contains("fondle")
                    || message.TextValue.Contains("squeeze") || message.TextValue.Contains("kneed")
                    || message.TextValue.Contains("tease")) && (message.TextValue.Contains("tit") || message.TextValue.Contains("breast")
                    || message.TextValue.Contains("boob") || message.TextValue.Contains("chest")))
                {
                    foreach (var item in Symptoms)
                    {
                        item.IncreaseSymptom();
                    }
                }
            }
        }
    }
}
