using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntry
{
    public string uid;
    public string timestamp = "";
    public long score = 0L;
    public string[] scores = ScoreBook.scorenames;

    public ScoreEntry(string uid, string timestamp, long score)
    {
        this.uid = uid;
        this.timestamp = timestamp;
        this.score = score;
    }

    public ScoreEntry(Dictionary<string, object> dic)
    {
        FromDictionary(dic);
    }

    public Dictionary<string, object> ToDictionary()
    {
        var dic = new Dictionary<string, object>();
        dic["uid"] = uid;
        dic["timestamp"] = timestamp;
        dic["score"] = score;

        return dic;
    }

    public void FromDictionary(Dictionary<string, object> dic)
    {
        uid = (string)dic["uid"];
        timestamp = (string)dic["timestamp"];
        score = (long)dic["score"];
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(uid);
        sb.AppendLine(timestamp);
        sb.Append(score.ToString());

        return sb.ToString();
    }
}