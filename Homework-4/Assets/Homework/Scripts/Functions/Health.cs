public class Health
{
    private int _health;
    private int _maxHealth;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    public void ReduceHealth(int value)
    {
        if (value < 0 && _health <= 0) return;
        _health -= value;
    }

    public void AddHealth(int value)
    {
        if (value < 0 && _maxHealth <= _health) return;
        _health += value;
    }

    public int GetHealth() => _health;
}
