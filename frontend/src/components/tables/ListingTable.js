import React, { useEffect, useState } from 'react'
import { connect } from 'react-redux'
import { Table, Divider, Tag, Button, Modal, message } from 'antd'
import { getListings, deleteListing } from '../../services/listingService'
import WrappedListingForm from '../forms/ListingForm'
import { updateListing, createListing } from '../../actions/actionCreator'

const { Column } = Table

const ListingTable = ({ ...props }) => {
    const { updateListing, createListing, listing, currentUser } = props
    const [listings, setListings] = useState([])
    const [visibleCreate, setVisibleCreate] = useState(false)
    const [visibleUpdate, setVisibleUpdate] = useState(false)

    useEffect(() => {
        getListings().then(res => {
            setListings(res)
        })
    }, [])

    const handleCreate = () => {
        // TODO: Create Listing
        setVisibleCreate(true)
        createListing()
    }
    const saveCreateListing = () => {
        //refresh listing after created new listing 
        setVisibleCreate(false)
        getListings().then(res => {
            setListings(res)
        })
    }

    const handleCreateCancel = () => {
        setVisibleCreate(false)
    }

    const handleUpdate = (listing) => {
        setVisibleUpdate(true)
        updateListing(listing)
    }

    const saveUpdateListing = (updateListing) => {
        setVisibleUpdate(false)
        //refresh listing after updating 
        getListings().then(res => {
            setListings(res)
        })
    }

    const handleUpdateCancel = () => {
        setVisibleUpdate(false)
    }

    const handleDelete = (id) => {
        deleteListing(id).then(res => {
            getListings().then(res => {
                setListings(res)
            })
        }).catch(err => {
            message.error('Delete Failed')
        })
    }

    return (
        <React.Fragment>
            <h3>Listing</h3>
            <Button onClick={handleCreate} type="primary" style={{ marginBottom: 16 }}>
                Add a Listing
            </Button>
            <Modal
                title="Create Listing"
                visible={visibleCreate}
                onOk={handleCreate}
                onCancel={handleCreateCancel}
                footer={[]}
            >
                <WrappedListingForm currentUser={currentUser} listing={{}} saveCreateListing={saveCreateListing} />
            </Modal>
            <Modal
                title="Update Listing"
                visible={visibleUpdate}
                onOk={saveUpdateListing}
                onCancel={handleUpdateCancel}
                footer={[]}
            >
                <WrappedListingForm currentUser={currentUser} listing={listing} saveUpdateListing={saveUpdateListing} />
            </Modal>
            <Table rowKey={listing => listing.listingId} dataSource={listings}>

                <Column title="Price" dataIndex="price" key="price" />
                <Column title="Address" dataIndex="address" key="address" />
                <Column title="Created" dataIndex="created" key="created" />
                <Column
                    title="Status"
                    dataIndex="status"
                    key="status"
                    render={status => (
                        <span>

                            <Tag color="blue" >
                                {status}
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

                            {currentUser.role === 'SalesDepartmentAdmin' && record.status === 'withdrawn' &&
                                <React.Fragment>
                                    <Divider type="vertical" />
                                    <a href="" onClick={(e) => { e.preventDefault(); handleDelete(record.listingId) }}>Delete</a>
                                </React.Fragment>
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
        listing: state.listingReducer.listing,
        currentUser: state.authReducer.user,
    }
}

const mapDispatchToProps = {
    updateListing,
    createListing
}


export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ListingTable)
