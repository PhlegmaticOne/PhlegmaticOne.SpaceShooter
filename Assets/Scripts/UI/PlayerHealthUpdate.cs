using System;
using System.Globalization;
using AssemblyCSharp.Assets.Health;
using TMPro;
using UnityEngine;

public class PlayerHealthUpdate : MonoBehaviour
{
    private TextMeshProUGUI _text;
    void OnEnable()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Player.Enabled += PlayerOnEnabled;
        Player.Disabled += PlayerOnDisabled;
    }

    private void PlayerOnDisabled(object sender, EventArgs e)
    {
        Player.Instance.GetComponent<Health>().HealthChanged -= OnHealthChanged;
        Player.Enabled -= PlayerOnEnabled;
        Player.Disabled -= PlayerOnDisabled;
    }

    private void PlayerOnEnabled(object sender, EventArgs e)
    {
        var health = Player.Instance.GetComponent<Health>();
        health.HealthChanged += OnHealthChanged;
        _text.text = health.GetHealth().ToString(CultureInfo.InvariantCulture);
    }

    private void OnHealthChanged(object sender, float health)
    {
        _text.text = health.ToString(CultureInfo.InvariantCulture);
    }
}
