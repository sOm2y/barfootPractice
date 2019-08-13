import React, { useEffect, useState } from 'react'
import { Table, Divider, Tag, Button } from 'antd';
import { getStaffs } from '../../services/staffService';

const { Column } = Table;


const StaffTable = ({ ...props }) => {
    const [staffs, setStaffs] = useState([])

    useEffect(() => {
        getStaffs(JSON.parse(localStorage.getItem('token'))).then(res => {
            setStaffs(res)
        })
    }, [])

    const handleCreate = () => {
        // TODO: Create Staff
    }

    return (
        <React.Fragment>
            <h3>Staff</h3>
            <Button onClick={handleCreate} type="primary" style={{ marginBottom: 16 }}>
                Add a Staff
            </Button>
            <Table rowKey={staff => staff.staffId} dataSource={staffs}>

                <Column title="Name" dataIndex="name" key="name" />
                <Column title="Email" dataIndex="email" key="email" />
                <Column title="Phone" dataIndex="phone" key="phone" />
                <Column
                    title="Role"
                    dataIndex="role"
                    key="role"
                    render={role => (
                        <span>

                            <Tag color="blue" >
                                {role}
                            </Tag>

                        </span>
                    )}
                />
                <Column
                    title="Action"
                    key="action"
                    render={(text, record) => (
                        <span>
                            <a href="" onClick={(e) => { }}>Update</a>
                            <Divider type="vertical" />
                            {
                                <a href="" onClick={(e) => { }}>Delete</a>
                            }
                        </span>
                    )}
                />
            </Table>
        </React.Fragment>
    )
}

export default StaffTable