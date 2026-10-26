namespace BehavioralPatterns;

public interface IDamagble
{
    int Health { get; }
    bool IsDead { get; }
    void TakeDamage(int amount);
    void Restore(int amount);
}