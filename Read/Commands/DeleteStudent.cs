﻿using MediatR;
using Read.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.Commands
{
    public record DeleteStudent(StudentJson student) : IRequest<bool>;
}
