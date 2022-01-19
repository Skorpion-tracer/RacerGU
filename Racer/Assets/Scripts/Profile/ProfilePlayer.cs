using AnalyticsTools;
using Tools;

namespace Profile
{
    internal class ProfilePlayer
    {
        public ProfilePlayer(float speedCar, UnityAdsTools unityAdsTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticsTools = new UnityanAlyticsTools();
            AdsShower = unityAdsTools;
        }

        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticsTools AnalyticsTools { get; }
        public IAdsShower AdsShower { get; }
    }
}
