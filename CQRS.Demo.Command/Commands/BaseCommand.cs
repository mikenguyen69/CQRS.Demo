using CQRSlite.Commands;
using System;

namespace CQRS.Demo.Command.Commands
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }
    }
}
