﻿using System.Collections.Generic;
using System.Linq;
using _09.SnsDomain.Models.Circles;
using _09.SnsDomain.Models.Users;

namespace _09.SnsDomain.Models.CircleMembers
{
    public class CircleMembers
    {
        private readonly User owner;
        private readonly List<User> members;

        public CircleMembers(CircleId id, User owner, List<User> members)
        {
            Id = id;
            this.owner = owner;
            this.members = members;
        }

        public CircleId Id { get; }

        public int CountMembers()
        {
            return members.Count() + 1;
        }

        public int CountPremiumMembers(bool containsOwner = true)
        {
            var premiumUserNumber = members.Count(member => member.IsPremium);
            if (containsOwner)
            {
                return premiumUserNumber + (owner.IsPremium ? 1 : 0);
            }
            else
            {
                return premiumUserNumber;
            }
        }
    }
}