using CQRSlite.Commands;
using System;

namespace CQRS.Demo.Core.Command
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }
    }
}
