//////////////////////////////////////////////////////////////////////////////
// bl_TopUserInfo.cs
//
//
//                       Lovatto Studio 2015
//////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bl_TopUserInfo : MonoBehaviour
{
    public string rank = "";
    public string mname = "";
    public int kills = 0;
    public int deaths = 0;
    public int score = 0;
    [Space(5)]
    public Text m_number = null;
    public Text m_name = null;
    public Text m_kills = null;
    public Text m_deaths = null;
    public Text m_score = null;
   
    /// <summary>
    /// get info and update Text
    /// </summary>
    public void CreateUser()
    {
        m_number.text = rank.ToString(); 
        m_name.text = mname;
        m_kills.text = kills.ToString();
        m_deaths.text = deaths.ToString();
        m_score.text = score.ToString(); 
    }
    /// <summary>
    /// when is admin 
    /// </summary>
    public void isAdmin()
    {
        m_number.color = Color.red;
        m_name.color = Color.red;
        m_kills.color = Color.red;
        m_deaths.color = Color.red;
        m_score.color = Color.red;
    }

}