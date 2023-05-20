using Assets.CodeBase.Data.StaticData.DropLoot;

namespace Assets.CodeBase.App.Services
{
    public class ProbabilityLootObject
    {
        private float _startPointOfInterval;
        private float _endPointOfInterval;
        private LootWithProbability _lootWithoutProbability;
        public LootWithProbability LootWithoutProbability => _lootWithoutProbability;
        public ProbabilityLootObject(float startPointOfInterval, float endPointOfIntreval, LootWithProbability lootWithoutProbability)
        {
            _startPointOfInterval = startPointOfInterval;
            _endPointOfInterval = endPointOfIntreval;
            _lootWithoutProbability = lootWithoutProbability;
        }
        public bool InInterval(float value)
        {
            if (_startPointOfInterval <= value && _endPointOfInterval > value)
                return true;
            else
                return false;
        }
    }
}
