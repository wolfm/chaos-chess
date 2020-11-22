﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightTargeter : Targeter
{
    public override List<Vector2Int> GetTargets(int piece_row, int piece_col, Tile[,] tiles)
    {
        int height = tiles.GetLength(0);
        int width = tiles.GetLength(1);

        List<Vector2Int> targets = new List<Vector2Int>();
        Vector2Int[] directions = new Vector2Int[8]
        {
            new Vector2Int(2, -1),
            new Vector2Int(2, 1),
            new Vector2Int(1, 2),
            new Vector2Int(-1, 2),
            new Vector2Int(-2, 1),
            new Vector2Int(-2, -1),
            new Vector2Int(-1, -2),
            new Vector2Int(1, -2)
        };

        foreach (Vector2Int direction in directions)
        {
            int c_delta = direction.x;
            int r_delta = direction.y;

            int r = piece_row + r_delta;
            int c = piece_col + c_delta;

            // Add this tile to targets unless there's a friendly piece on it
            if (r >= 0 && c >= 0 && r < height && c < width &&
                !(tiles[r, c].Piece
                && tiles[r, c].Piece.isWhite == tiles[piece_row, piece_col].Piece.isWhite))
            {
                targets.Add(new Vector2Int(c, r));
            }

        }

        return targets;
    }
}