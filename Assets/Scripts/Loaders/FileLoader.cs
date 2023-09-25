using ContactList.FIleFields;
using UnityEngine;

namespace ContactList.Loaders
{
    public class FileLoader : MonoBehaviour
    {
        [SerializeField] private TextAsset _file;

        private EmployeeData _employeeData;
        
        public EmployeeData GetData()
        {
            _employeeData =  JsonUtility.FromJson<EmployeeData>(_file.text);

            return _employeeData;
        }

        public Employer GetEmployer(int id)
        {
            if (_employeeData == null)
            {
                _employeeData =  JsonUtility.FromJson<EmployeeData>(_file.text);
            }
            else
            {
                foreach (var data in _employeeData.data)
                {
                    if (data.id == id)
                    {
                        return data;
                    }
                }
            }

            return null;
        }
    }
}