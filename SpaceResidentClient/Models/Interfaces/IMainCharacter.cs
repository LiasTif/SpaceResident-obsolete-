namespace SpaceResidentClient.Models.Interfaces
{
    interface IMainCharacter : ICharacter
    {
        string? Job { get; set; }

        #region characteristics
        byte Linguistics { get; set; }
        byte Naturalistics { get; set; }
        byte Existentialism { get; set; }
        byte Relationships { get; set; }
        byte Logic { get; set; }
        byte Space { get; set; }
        byte Kinetics { get; set; }
        #endregion

        #region skills
        #region Business
        byte HRManagement { get; set; }
        byte Marketing { get; set; }
        byte MacroFinancialManagement { get; set; }
        byte BusinessPlanning { get; set; }
        byte StationManagement { get; set; }
        #endregion
        #region Professions
        byte Doctor { get; set; }
        byte Lawyer { get; set; }
        byte Clerk { get; set; }
        byte Musician { get; set; }
        byte Artist { get; set; }
        byte Architect { get; set; }
        byte Programmer { get; set; }
        byte Engineer { get; set; }
        byte Laborer { get; set; }
        byte SpaceСourier { get; set; }
        byte PlanetaryСourier { get; set; }
        byte LandTransportCourier { get; set; }
        #endregion
        #region Transportation
        byte CorvetteControl { get; set; }
        byte DestroyersControl { get; set; }
        byte CruisersControl { get; set; }
        byte BattleshipsControl { get; set; }
        byte AircraftCarriersControl { get; set; }
        byte TitansControl { get; set; }
        byte LandTransportControl { get; set; }
        byte FlyingAtmosphericTransportControl { get; set; }
        #endregion

        #region Sciences
        byte Mathematics { get; set; }
        byte Physics { get; set; }
        byte Chemistry { get; set; }
        byte Biology { get; set; }
        byte Geography { get; set; }
        byte Astronomy { get; set; }
        byte Philosophy { get; set; }
        byte Psychology { get; set; }
        #endregion
        #region SelfDevelopment
        byte Empathy { get; set; }
        byte Will { get; set; }
        byte SelfDiscipline { get; set; }
        byte CriticalThinking { get; set; }
        byte SelfKnowledge { get; set; }
        #endregion
        #region Communication
        byte HumanSpeech { get; set; }
        byte VibrationsOfVunTi { get; set; }
        byte TickingOfVunMisak  { get; set; }
        byte CommunicationByVunFlantSpores { get; set; }
        #endregion
        #region Informatics
        byte Software { get; set; }
        byte AlgorithmsAndDataStructures { get; set; }
        byte ProgrammingLanguages { get; set; }
        byte ArtificialIntelligence { get; set; }
        byte Cybersecurity { get; set; }
        #endregion
        #region Technique
        byte NeurophysicalSystems { get; set; }
        byte CyberneticSystems { get; set; }
        byte Engineering { get; set; }
        byte Hardware { get; set; }
        #endregion
        #endregion
    }
}