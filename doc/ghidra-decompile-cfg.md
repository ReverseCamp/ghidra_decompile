## main loop

```flow
st=>start: Start
op1=>operation: AttributeId::Initialize
op2=>operation: ElementId::Initialize
op3=>operation: CapabilityPoint::InitializeAll
op4=>operation: GhidraCapability::readCommand
cond=>condition: status != 0
e=>end

st->op1->op2->op3->op4->cond
cond(yes)->e
cond(no)->op4
```



## readcommand

```flow
st=>start: Start
op=>operation: ArchitectureGhidra::readToAnyBurst
cond=>condition: type != 2
e=>end
op1=>operation: ArchitectureGhidra::readStringStream
cond2=>condition: commandmap find
op2=>condition: doit方法

st->op->cond
cond(no)->op1
op1->cond2
cond2(no)->e
cond2(yes)->op2

cond(yes)->op
```



## doit

```flow
st=>start: Start
op=>operation: 根据function执行对应的loadParameters
op2=>operation: 根据function执行对应的rawAction
op3=>operation: sendResult
e=>end

st->op->op2->op3->e
```

| command     | loadParameters                                               | rawAction                  | mark            |
| ----------- | ------------------------------------------------------------ | -------------------------- | --------------- |
|             |                                                              | RegisterProgram::rawAction |                 |
|             |                                                              | SetOptions::rawAction      |                 |
| decompileAt | DecompileAt::loadParameters<br>GhidraCommand::loadParameters | DecompileAt::rawAction     | refresh也会触发 |
| flushNative | GhidraCommand::loadParameters                                | FlushNative::rawAction     |                 |
|             |                                                              |                            |                 |
|             |                                                              |                            |                 |



















