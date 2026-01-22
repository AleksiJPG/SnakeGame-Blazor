using System;
using System.Collections.Generic;

namespace SnakeGame.GameEngine;

public record Point(int X, int Y);

public enum Direction { Up, Down, Left, Right }

public class SnakeGame
{
    public int Width { get; }
    public int Height { get; }

    public List<Point> Snake { get; private set; } = new();
    public Point Food { get; private set; }
    public Direction CurrentDirection { get; private set; }
    public bool IsGameOver { get; private set; }

    private Random _rand = new();

    public SnakeGame(int width, int height)
    {
        Width = width;
        Height = height;
        Snake.Add(new Point(width / 2, height / 2));
        CurrentDirection = Direction.Right;
        SpawnFood();
    }

    public void Update()
    {
        if (IsGameOver) return;

        var head = Snake[0];
        var newHead = CurrentDirection switch
        {
            Direction.Up => new Point(head.X, head.Y - 1),
            Direction.Down => new Point(head.X, head.Y + 1),
            Direction.Left => new Point(head.X - 1, head.Y),
            Direction.Right => new Point(head.X + 1, head.Y),
            _ => head
        };

        // Collision
        if (newHead.X < 0 || newHead.X >= Width || newHead.Y < 0 || newHead.Y >= Height || Snake.Contains(newHead))
        {
            IsGameOver = true;
            return;
        }

        Snake.Insert(0, newHead);

        if (newHead == Food)
        {
            SpawnFood();
        }
        else
        {
            Snake.RemoveAt(Snake.Count - 1);
        }
    }

    public void ChangeDirection(Direction dir)
    {
        if (CurrentDirection == Direction.Up && dir == Direction.Down) return;
        if (CurrentDirection == Direction.Down && dir == Direction.Up) return;
        if (CurrentDirection == Direction.Left && dir == Direction.Right) return;
        if (CurrentDirection == Direction.Right && dir == Direction.Left) return;
        CurrentDirection = dir;
    }

    private void SpawnFood()
    {
        Point p;
        do
        {
            p = new Point(_rand.Next(0, Width), _rand.Next(0, Height));
        } while (Snake.Contains(p));

        Food = p;
    }
}
