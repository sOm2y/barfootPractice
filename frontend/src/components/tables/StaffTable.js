import React, { useEffect, useState } from 'react'
import { connect } from 'react-redux'
import { Table, Divider, Tag, Button, Modal, message } from 'antd';
import WrappedStaffForm from '../forms/StaffForm'
import { getStaffs, deleteStaff } from '../../services/staffService';
import { createStaff, updateStaff } from '../../actions/actionCreator';

const { Column } = Table;


const StaffTable = ({ ...props }) => {
    const { updateStaff, createStaff, staff, currentUser } = props
    const [staffs, setStaffs] = useState([])
    const [visibleCreate, setVisibleCreate] = useState(false)
    const [visibleUpdate, setVisibleUpdate] = useState(false)

    useEffect(() => {
        getStaffs(JSON.parse(localStorage.getItem('token'))).then(res => {
            setStaffs(res)
        })
    }, [])

    const handleCreate = () => {
        // TODO: Create staff
        setVisibleCreate(true)
        createStaff()
    }
    const saveCreateStaff = () => {
        //refresh staff after created new listing 
        setVisibleCreate(false)
        getStaffs().then(res => {
            setStaffs(res)
        })
    }

    const handleCreateCancel = () => {
        setVisibleCreate(false)
    }

    const handleUpdate = (staff) => {
        setVisibleUpdate(true)
        updateStaff(staff)
    }

    const saveUpdateStaff = () => {
        setVisibleUpdate(false)
        //refresh staff after updating 
        getStaffs().then(res => {
            setStaffs(res)
        })
    }

    const handleUpdateCancel = () => {
        setVisibleUpdate(false)
    }

    const handleDelete = (id) => {
        deleteStaff(id).then(res => {
            getStaffs().then(res => {
                setStaffs(res)
            })
        }).catch(err => {
            message.error('Delete Failed')
        })
    }

    return (
        <React.Fragment>
            <h3>Staff</h3>
            <Button onClick={handleCreate} type="primary" style={{ marginBottom: 16 }}>
                Add a Staff
            </Button>
            <Modal
                title="Create Staff"
                visible={visibleCreate}
                onCancel={handleCreateCancel}
                footer={[]}
            >
                <WrappedStaffForm currentUser={currentUser} staff={{}} saveCreateStaff={saveCreateStaff} />
            </Modal>
            <Modal
                title="Update Staff"
                visible={visibleUpdate}
                onCancel={handleUpdateCancel}
                footer={[]}
            >
                <WrappedStaffForm currentUser={currentUser} staff={staff} saveUpdateStaff={saveUpdateStaff} />
            </Modal>
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
                            <a href="" onClick={(e) => { e.preventDefault(); handleUpdate(record) }}>Update</a>
                            <Divider type="vertical" />
                            {
                                <a href="" onClick={(e) => { e.preventDefault(); handleDelete(record.staffId) }}>Delete</a>
                            }
                        </span>
                    )}
                />
            </Table>
        </React.Fragment>
    )
}
const mapStateToProps = (state, props) => {
    return {
        staff: state.staffReducer.staff,
        currentUser: state.authReducer.user,
    }
}

const mapDispatchToProps = {
    updateStaff,
    createStaff
}


export default connect(
    mapStateToProps,
    mapDispatchToProps
)(StaffTable)
