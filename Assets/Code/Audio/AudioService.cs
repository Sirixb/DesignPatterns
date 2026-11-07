namespace GameAudio
{
    public interface AudioService
    {
        void PlaySfx(AudioIds id);
        void PlayMusic(AudioIds id);
        void StopMusic();
    }
}
