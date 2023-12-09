using SpaceResidentClient.ViewModels.CharacterCreation;

namespace SpaceResidentClientTest.CharacterCreaton
{
    public class CharacterSkillsTest
    {
        [Test]
        public void IncreaseCharacteristicTest()
        {
            CreationSkillsViewModel creationSkillsViewModel = new();

            creationSkillsViewModel.Logic++;
        }
    }
}
