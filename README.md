NServiceBus-issue2306
=====================
This is a basic solution to reproduce the issue logged here: https://github.com/Particular/NServiceBus/issues/2306

It contains the following projects:
* Repro.NServiceBus-4.6.1.WithIssue -> NServiceBus Host running version 4.6.1, Castle.Core 3.3.0, Castle.Windsor 3.2.1, which highlights the issue
* Repro.NServiceBus-4.6.1.WithoutIssue -> NServiceBus host running version 4.6.1, Castle.Core 3.3.0, Castle.Windsor 3.2.1, which does not have the issue (due to a workaround)
* Repro.NServiceBus-5.0.1 -> NServiceBus host running 5.0.1, Castle.Core 3.3.0, Castle.Windsor 3.3.0, which does not exhibit the issue
* Repro.Shared -> Shared code project. The intention was to put an interface/implementation here to give Castle.Windsor something to register but it turned out to be unnecessary

Expected Behaviour: All 3 hosts output the text 'Endpoint Started' to the console when startup is complete.

Actual Behaviour: Repro.NServiceBus-4.6.1.WithIssue does not output the text
