using Firebase;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Auth : MonoBehaviour
{
    //public GameObject loginPanel;
    public Text msgText;

    //public InputField

    private void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://capsulegameheaven.firebaseio.com/");

        if (string.IsNullOrEmpty(Leaderboard.UserID))
        {
            //Debug.Log("Login");
            LoginAnonymous();
        }
    }

    public void LoginAnonymous()
    {
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync().ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
            {
                FirebaseUser newUser = task.Result;
                Leaderboard.UserID = string.Format("{0}\n{1}", newUser.UserId, newUser.Email);

                //Debug.Log(string.Format("Login Anonymous\n{0}\n{1}", newUser.UserId, newUser.Email));
                //msgText.text = string.Format("Login Anonymous\n{0}\n{1}", newUser.UserId, newUser.Email);
            }
        });
    }
}