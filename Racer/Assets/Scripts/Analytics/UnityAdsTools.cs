using UnityEngine;
using UnityEngine.Advertisements;

namespace AnalyticsTools
{
    public class UnityAdsTools : MonoBehaviour, IAdsShower
    {
        private const string GameId = "4520561";
        private const string BannerPlacementId = "Banner_Android";
        private const string InterstitialPlacemenId = "Interstitial_Android";

        private void Start()
        {
            Advertisement.Initialize(GameId);
        }

        public void ShowBanner()
        {
            Advertisement.Show(BannerPlacementId);
        }

        public void ShowInterstitial()
        {
            Advertisement.Show(InterstitialPlacemenId);
        }
    }
}
