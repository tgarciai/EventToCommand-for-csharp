# C# Easy Command pattern 
This library is used to map custom events to commands,
when a event is dispatched the asociated command is executed.

Example of use:

    EventToCommandMapper commandToEventMapper = new EventToCommandMapper();

    TestCommandA commandA = new TestCommandA();
    TestCommandB commandB = new TestCommandB();

    commandToEventMapper.MapCommand(commandA,TestEventA.TYPE);commandToEventMapper.MapCommand(commandB,TestEventB.TYPE);


    var evtA = new TestEventA(TestEventA.TYPE,"hello");
    var evtB = new TestEventA(TestEventB.TYPE,"world");

    evtA.dispatch();
    evtB.dispatch();
