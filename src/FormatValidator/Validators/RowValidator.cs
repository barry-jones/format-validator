﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatValidator.Validators
{
    public class RowValidator : Validator
    {
        private char _columnSeperator;
        private ValidatorGroup[] _columns;

        public RowValidator(char columnSeperator)
        {
            _columns = new ValidatorGroup[0];
            _columnSeperator = columnSeperator;
        }
        
        public override bool IsValid(string toCheck)
        {
            bool isValid = true;
            string[] parts = toCheck.Split(_columnSeperator);

            for(int i = 0; i < parts.Length; i++)
            {
                if(i < _columns.Length)
                {
                    bool currentResult = _columns[i].IsValid(parts[i]);
                    Errors.AddRange(_columns[i].GetErrors());
                    isValid = isValid & currentResult;
                }
            }

            return isValid;
        }

        public void AddColumnValidator(int toColumn, IValidator validator)
        {
            CheckAndResizeColumnList(toColumn);

            _columns[toColumn - 1].Add(validator);
        }

        private void CheckAndResizeColumnList(int allowColumnAt)
        {
            if (_columns.Length < allowColumnAt)
            {
                ValidatorGroup[] resizedColumns = new ValidatorGroup[allowColumnAt];
                for (int i = 0; i < _columns.Length; i++)
                {
                    resizedColumns[i] = _columns[i];
                }

                _columns = resizedColumns;

                MakeSureColumnsAreNotNull();
            }
        }

        private void MakeSureColumnsAreNotNull()
        {
            for (int i = 0; i < _columns.Length; i++)
            {
                if (_columns[i] == null)
                {
                    _columns[i] = new ValidatorGroup();
                }
            }
        }
    }
}