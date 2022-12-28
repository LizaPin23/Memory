using UnityEngine;

public class GameFinishMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _visibleName = "VisibleBool";
    [SerializeField] private ScoreTextView _finalScore;

    public void SetFinalScore(int value)
    {
        _finalScore.OnShowScoreText(value);
    }

    public void Show()
    {
        _animator.SetBool(_visibleName, true);
    }

    public void Hide()
    {
        _animator.SetBool(_visibleName, false);
    }


}
