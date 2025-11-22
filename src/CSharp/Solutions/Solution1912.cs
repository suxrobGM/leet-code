using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1912
{
    /// <summary>
    /// 1912. Design Movie Rental System - Hard
    /// <a href="https://leetcode.com/problems/design-movie-rental-system">See the problem</a>
    /// </summary>
    public class MovieRentingSystem
    {
        // (shop, movie) -> price
        private readonly Dictionary<(int, int), int> _price;

        // movie -> available copies sorted by (price, shop)
        private readonly Dictionary<int, SortedSet<Node>> _availableByMovie;

        // all rented copies sorted by (price, shop, movie)
        private readonly SortedSet<Node> _rented;

        // Node representing a single copy of a movie at a shop
        private struct Node
        {
            public int Shop;
            public int Movie;
            public int Price;

            public Node(int shop, int movie, int price)
            {
                Shop = shop;
                Movie = movie;
                Price = price;
            }
        }

        // Comparer for available movies of a given movie ID:
        // sort by price asc, then shop asc
        private class AvailableComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                int cmp = x.Price.CompareTo(y.Price);
                if (cmp != 0) return cmp;
                // For a given movie, shop is unique, so (price, shop) is unique
                return x.Shop.CompareTo(y.Shop);
            }
        }

        // Comparer for rented movies:
        // sort by price asc, then shop asc, then movie asc
        private class RentedComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                int cmp = x.Price.CompareTo(y.Price);
                if (cmp != 0) return cmp;

                cmp = x.Shop.CompareTo(y.Shop);
                if (cmp != 0) return cmp;

                cmp = x.Movie.CompareTo(y.Movie);
                return cmp;
            }
        }

        public MovieRentingSystem(int n, int[][] entries)
        {
            _price = new Dictionary<(int, int), int>();
            _availableByMovie = new Dictionary<int, SortedSet<Node>>();
            _rented = new SortedSet<Node>(new RentedComparer());

            foreach (var e in entries)
            {
                int shop = e[0];
                int movie = e[1];
                int price = e[2];

                _price[(shop, movie)] = price;

                if (!_availableByMovie.TryGetValue(movie, out var set))
                {
                    set = new SortedSet<Node>(new AvailableComparer());
                    _availableByMovie[movie] = set;
                }

                set.Add(new Node(shop, movie, price));
            }
        }

        // Return shops with an unrented copy of 'movie', sorted by (price, shop)
        public IList<int> Search(int movie)
        {
            var result = new List<int>();

            if (!_availableByMovie.TryGetValue(movie, out var set))
                return result;

            int count = 0;
            foreach (var node in set)
            {
                result.Add(node.Shop);
                if (++count == 5) break;
            }

            return result;
        }

        // Rent the given movie from the given shop
        public void Rent(int shop, int movie)
        {
            int price = _price[(shop, movie)];
            var node = new Node(shop, movie, price);

            // Remove from available set for that movie
            if (_availableByMovie.TryGetValue(movie, out var set))
            {
                set.Remove(node);
            }

            // Add to rented set
            _rented.Add(node);
        }

        // Drop off a previously rented movie
        public void Drop(int shop, int movie)
        {
            int price = _price[(shop, movie)];
            var node = new Node(shop, movie, price);

            // Remove from rented set
            _rented.Remove(node);

            // Add back to available set for that movie
            if (!_availableByMovie.TryGetValue(movie, out var set))
            {
                set = new SortedSet<Node>(new AvailableComparer());
                _availableByMovie[movie] = set;
            }

            set.Add(node);
        }

        // Return the cheapest 5 rented movies sorted by (price, shop, movie)
        public IList<IList<int>> Report()
        {
            var result = new List<IList<int>>();
            int count = 0;

            foreach (var node in _rented)
            {
                result.Add(new List<int> { node.Shop, node.Movie });
                if (++count == 5) break;
            }

            return result;
        }
    }
}
