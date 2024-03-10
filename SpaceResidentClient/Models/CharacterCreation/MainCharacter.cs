using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Models.Interfaces.Characters;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal partial class MainCharacter(string job, string name, string surname, bool isFemale, char race, int age) : ObservableObject, IMainCharacter
    {
        #region props
        int ICharacter.Age { get; set; } = age;
        string IMainCharacter.Job { get; set; } = job;
        byte IMainCharacter.Linguistics { get; set; }
        byte IMainCharacter.Naturalistics { get; set; }
        byte IMainCharacter.Existentialism { get; set; }
        byte IMainCharacter.Relationships { get; set; }
        byte IMainCharacter.Logic { get; set; }
        byte IMainCharacter.Space { get; set; }
        byte IMainCharacter.Kinetics { get; set; }
        byte IMainCharacter.HRManagement { get; set; }
        byte IMainCharacter.Marketing { get; set; }
        byte IMainCharacter.MacroFinancialManagement { get; set; }
        byte IMainCharacter.BusinessPlanning { get; set; }
        byte IMainCharacter.StationManagement { get; set; }
        byte IMainCharacter.Doctor { get; set; }
        byte IMainCharacter.Lawyer { get; set; }
        byte IMainCharacter.Clerk { get; set; }
        byte IMainCharacter.Musician { get; set; }
        byte IMainCharacter.Artist { get; set; }
        byte IMainCharacter.Architect { get; set; }
        byte IMainCharacter.Programmer { get; set; }
        byte IMainCharacter.Engineer { get; set; }
        byte IMainCharacter.Laborer { get; set; }
        byte IMainCharacter.SpaceСourier { get; set; }
        byte IMainCharacter.PlanetaryСourier { get; set; }
        byte IMainCharacter.LandTransportCourier { get; set; }
        byte IMainCharacter.CorvetteControl { get; set; }
        byte IMainCharacter.DestroyersControl { get; set; }
        byte IMainCharacter.CruisersControl { get; set; }
        byte IMainCharacter.BattleshipsControl { get; set; }
        byte IMainCharacter.AircraftCarriersControl { get; set; }
        byte IMainCharacter.TitansControl { get; set; }
        byte IMainCharacter.LandTransportControl { get; set; }
        byte IMainCharacter.FlyingAtmosphericTransportControl { get; set; }
        byte IMainCharacter.Mathematics { get; set; }
        byte IMainCharacter.Physics { get; set; }
        byte IMainCharacter.Chemistry { get; set; }
        byte IMainCharacter.Biology { get; set; }
        byte IMainCharacter.Geography { get; set; }
        byte IMainCharacter.Astronomy { get; set; }
        byte IMainCharacter.Philosophy { get; set; }
        byte IMainCharacter.Psychology { get; set; }
        byte IMainCharacter.Empathy { get; set; }
        byte IMainCharacter.Will { get; set; }
        byte IMainCharacter.SelfDiscipline { get; set; }
        byte IMainCharacter.CriticalThinking { get; set; }
        byte IMainCharacter.SelfKnowledge { get; set; }
        byte IMainCharacter.HumanSpeech { get; set; }
        byte IMainCharacter.VibrationsOfVunTi { get; set; }
        byte IMainCharacter.TickingOfVunMisak { get; set; }
        byte IMainCharacter.CommunicationByVunFlantSpores { get; set; }
        byte IMainCharacter.Software { get; set; }
        byte IMainCharacter.AlgorithmsAndDataStructures { get; set; }
        byte IMainCharacter.ProgrammingLanguages { get; set; }
        byte IMainCharacter.ArtificialIntelligence { get; set; }
        byte IMainCharacter.Cybersecurity { get; set; }
        byte IMainCharacter.NeurophysicalSystems { get; set; }
        byte IMainCharacter.CyberneticSystems { get; set; }
        byte IMainCharacter.Engineering { get; set; }
        byte IMainCharacter.Hardware { get; set; }
        string ICharacter.Name { get; set; } = name;
        string ICharacter.Surname { get; set; } = surname;
        bool ICharacter.IsFemale { get; set; } = isFemale;
        char ICharacter.Race { get; set; } = race;
        #endregion
    }
}