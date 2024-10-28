namespace MKubiak.RTETestTask.PlayerUI
{
    public interface IPlayerUIService
    {
        /// <param name="player"> 
        /// Player for which menu shall show data.
        /// </param>
        void ShowMenu(PlayerFacade player);
        void HideMenu();
    }
}