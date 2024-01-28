using UnityEngine;
using UnityEngine.UI;
public class LeaderboardTestGUI : MonoBehaviour
{
    private string _nameInput = "";
    private string _scoreInput = "0";

    [SerializeField] private InputField inputField;
    [SerializeField] private TextMesh txt_Score;

    private void OnGUI()    
    {

        // Display high scores!
        for (int i = 0; i < Leaderboard.EntryCount; ++i)
        {
            var entry = Leaderboard.GetEntry(i);
            GUILayout.Label("Name: " + entry.name + ", Score: " + entry.score);
        }

        _nameInput = inputField.text;
        _scoreInput = txt_Score.text;

        int score;
        int.TryParse(_scoreInput, out score);

        Leaderboard.Record(_nameInput, score);

        // Reset for next input.
        _nameInput = "";
        _scoreInput = "0";
    }
}