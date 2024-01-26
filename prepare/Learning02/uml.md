Example:
```s
CLASS: Person
Attributes:
* _givenName : string
* _familyName : string
Behaviors:
* ShowName() : void
* ShowLastName() : void
```

--- 

```cs
CLASS: Job
Attributes:
* _company : string
* _title : string
* _yearEnd : DateTime || int
* _yearStart : DateTime || int
Behaviors:
* Display() : void  // "Job Title (Company) StartYear-EndYear"
```

```cs
CLASS: Resume
Attributes:
* _name : string
* _jobs : List<Job>
Behaviors:
* Display() : void  // "Name, List of jobs"
```

